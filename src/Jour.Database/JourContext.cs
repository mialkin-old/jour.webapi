using Jour.Database.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Jour.Database
{
    public class JourContext : DbContext
    {
        private readonly DatabaseSettings _settings;

        public JourContext(DbContextOptions<JourContext> options, IOptions<DatabaseSettings> settings) : base(options)
        {
            _settings = settings.Value;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // May be already configured from unit tests.
            {
                optionsBuilder
                    .UseNpgsql("" +
                               $"Host={_settings.Host};" +
                               $"Database={_settings.Database};" +
                               $"Username={_settings.Username};" +
                               $"Password={_settings.Password}")
                    .UseSnakeCaseNamingConvention();
            }
        }

        public DbSet<Birthday> Birthdays { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Training> Training { get; set; }
    }
}