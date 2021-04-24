using Jour.Database.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Jour.Database
{
    public class JourContext : DbContext
    {
        public JourContext(DbContextOptions<JourContext> options) : base(options)
        {
        }

        public DbSet<Birthday> Birthdays { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}