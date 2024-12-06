
using FinalG5.Models;
using Microsoft.EntityFrameworkCore;


namespace FinalG5.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<Exercise> Exercises { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Cycling", Description = "Riding a bike for leisure or exercise", DifficultyLevel = 3, AverageTimeSpentPerWeek = 5.5, IsOutdoorActivity = true },
                new Hobby { Id = 2, Name = "Painting", Description = "Creating art using paint", DifficultyLevel = 4, AverageTimeSpentPerWeek = 3.0, IsOutdoorActivity = false },
                new Hobby { Id = 3, Name = "Hiking", Description = "Walking trails in nature", DifficultyLevel = 4, AverageTimeSpentPerWeek = 6.0, IsOutdoorActivity = true }
            );
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Pushups", Description = "Using your arms to move your body", Repetitions = 10, Sets = 3, RequiresEquipment = false },
                new Exercise { Id = 2, Name = "Squats", Description = "Squatting with legs", Repetitions = 8, Sets = 2, RequiresEquipment = false },
                new Exercise { Id = 3, Name = "BicepCurl", Description = "Curling dumbbells for biceps", Repetitions = 12, Sets = 4, RequiresEquipment = true }
            );
        }

    }
}
