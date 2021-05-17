using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Jour.WebAPI.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Jour.WebAPI.BackgroundServices.Workout
{
    public class WorkoutRabbitWorker : BackgroundService
    {
        private readonly IWorkoutParser _parser;
        private readonly ILogger<WorkoutRabbitWorker> _logger;
        private readonly IModel _channel;
        private const string QueueName = "telegram-workout-received";


        public WorkoutRabbitWorker(ConnectionFactory connectionFactory, IOptions<RabbitOptions> rabbitOptions, IWorkoutParser parser,
            ILogger<WorkoutRabbitWorker> logger)
        {
            RabbitOptions options = rabbitOptions.Value;

            connectionFactory.HostName = options.Hostname;
            connectionFactory.UserName = options.Username;
            connectionFactory.Password = options.Password;

            _parser = parser;
            _logger = logger;

            _logger.LogInformation("Creating connection");
            IConnection connection = connectionFactory.CreateConnection();
            connection.ConnectionShutdown += (sender, args) => _logger.LogInformation("Connection shutdown");

            _logger.LogInformation("Creating channel");
            _channel = connection.CreateModel();

            _channel.ModelShutdown += (sender, args) => _logger.LogInformation("Model shutdown");


            _channel.QueueDeclare(queue: QueueName, durable: true, exclusive: false, autoDelete: false,
                arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                string message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}, DeliveryTag: {1}", message, ea.DeliveryTag);

                if (_parser.TryParse(message, out var result))
                {
                    // Save to DB and ack
                    _channel.BasicAck(ea.DeliveryTag, false);
                }
            };

            consumer.ConsumerCancelled += (sender, eventArgs) => Console.WriteLine("Consumer canceled");
            consumer.Shutdown += (sender, eventArgs) => Console.WriteLine("Shutdown");

            _channel.BasicConsume(queue: QueueName, autoAck: false, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            
            return Task.CompletedTask;
        }
    }
}