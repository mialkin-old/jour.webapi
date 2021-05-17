#nullable enable
using Jour.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Jour.Database;
using Jour.WebAPI.BackgroundServices.Workout;
using Jour.WebAPI.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;

namespace Jour.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    config =>
                    {
                        config.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                        config.ExpireTimeSpan = TimeSpan.FromDays(30);
                        config.Events.OnRedirectToLogin = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            return Task.FromResult<object>(null);
                        }; // https://github.com/dotnet/aspnetcore/issues/9039#issuecomment-629617025

                        if (Env.IsDevelopment())
                        {
                            config.Cookie.SameSite = SameSiteMode.None;
                        }
                    });

            if (Env.IsDevelopment())
            {
                services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
                });
            }

            services.AddControllers()
                .AddNewtonsoftJson();
            
            services.AddSignalR();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Jour.WebAPI", Version = "v1"});
            });

            services.AddSingleton<IDateTime, MachineClockDateTime>();
            services.ConfigureCustomOptions(Configuration);

            string? connectionStr = Environment.GetEnvironmentVariable("JOUR_ConnectionString");
            if (string.IsNullOrEmpty(connectionStr))
                throw new ArgumentNullException("Connection string must not be empty.", nameof(connectionStr));

            services.AddDbContext<JourContext>(x => x
                .UseNpgsql(connectionStr, y => y.MigrationsAssembly("Jour.Database.Migrations"))
                .UseSnakeCaseNamingConvention());

            services.AddSingleton<ConnectionFactory>();
            services.AddSingleton<IWorkoutParser, WorkoutParser>();
            services.AddHostedService<WorkoutRabbitWorker>();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jour.WebAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();


            if (Env.IsDevelopment())
            {
                app.UseCors();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<WorkoutHub>("/workout-hub");
            });
        }
    }
}