using Jour.Database.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Jour.Database
{
    public sealed class JourContext : DbContext
    {
        private readonly DatabaseSettings _settings;

        public JourContext(DbContextOptions<JourContext> options, IOptions<DatabaseSettings> settings) : base(options)
        {
            _settings = settings.Value;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql($"" +
                           $"Host={_settings.Host};" +
                           $"Database={_settings.Database};" +
                           $"Username={_settings.Username};" +
                           $"Password={_settings.Password}")
                .UseSnakeCaseNamingConvention();

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Birthday> Birthdays { get; set; }
    }
}