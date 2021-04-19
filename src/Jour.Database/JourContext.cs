using Jour.Database.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Jour.Database
{
    public sealed class JourContext : DbContext
    {
        private readonly DatabaseSettings _settings;

        public JourContext(DbContextOptions<JourContext> options) : base(options)
        {
            //_settings = settings.Value;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql(
                    "Host=localhost;Database=jour;Username=postgres;Password=vpIKsULCBA",
                    x => x.MigrationsAssembly("Jour.WebAPI"))
                .UseSnakeCaseNamingConvention();

        public DbSet<Birthday> Birthdays { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Training> Training { get; set; }
    } 
}