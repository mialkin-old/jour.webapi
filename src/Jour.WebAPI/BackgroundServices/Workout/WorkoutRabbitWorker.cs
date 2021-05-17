using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jour.Database.Repositories;
using Jour.WebAPI.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Jour.WebAPI.BackgroundServices.Workout
{
    public class WorkoutRabbitWorker : BackgroundService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IWorkoutParser _parser;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<WorkoutRabbitWorker> _logger;
        private IModel? _channel;
        private const string QueueName = "telegram-workout-received";

        public WorkoutRabbitWorker(ConnectionFactory connectionFactory, IOptions<RabbitOptions> rabbitOptions,
            IWorkoutParser parser,
            IServiceScopeFactory scopeFactory,
            ILogger<WorkoutRabbitWorker> logger)
        {
            RabbitOptions options = rabbitOptions.Value;

            connectionFactory.HostName = options.Hostname;
            connectionFactory.UserName = options.Username;
            connectionFactory.Password = options.Password;

            _connectionFactory = connectionFactory;
            _parser = parser;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Creating connection");
            IConnection connection = _connectionFactory.CreateConnection();
            connection.ConnectionShutdown += (sender, args) => _logger.LogInformation("Connection shutdown");

            _logger.LogInformation("Creating channel");
            _channel = connection.CreateModel();
            _channel.ModelShutdown += (sender, args) => _logger.LogInformation("Model shutdown");

            _channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += ConsumerOnReceived;
            consumer.ConsumerCancelled += (sender, eventArgs) => Console.WriteLine("Consumer canceled");
            consumer.Shutdown += (sender, eventArgs) => Console.WriteLine("Shutdown");

            _channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);

            return Task.CompletedTask;
        }

        private async void ConsumerOnReceived(object? sender, BasicDeliverEventArgs ea)
        {
            try
            {
                byte[] body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($"Received {0}, DeliveryTag: {1}", message, ea.DeliveryTag);

                WorkoutMessage? result = await _parser.Parse(message);
                if (result != null)
                {
                    _logger.LogInformation("Message \"{Message}\" parsed", message);
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        IWorkoutRepository workoutRepository =
                            scope.ServiceProvider.GetRequiredService<IWorkoutRepository>();
                        await workoutRepository.SaveAsync(new Database.Dtos.Workout
                            {WorkoutDateUtc = result.MessageDate});
                        _logger.LogInformation("Message \"{Message}\" parsed", message);
                    }

                    _channel!.BasicAck(ea.DeliveryTag, false);
                    _logger.LogInformation("Message \"{Message}\" acknowledged", message);
                }
                else
                {
                    _logger.LogInformation("Unable to parse message \"{Message}\"", message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception: {Ex}", ex);
            }
        }
    }
}