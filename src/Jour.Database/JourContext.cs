using Jour.Database.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Jour.Database
{
    public sealed class JourContext : DbContext
    {
        public JourContext(DbContextOptions<JourContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSnakeCaseNamingConvention();

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Birthday> Birthdays { get; set; }
    }
}