
using FinalG5.Models;
using Microsoft.EntityFrameworkCore;


namespace FinalG5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }


        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<BoardGames> BoardGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>().ToTable("TeamMembers");

            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Cycling", Description = "Riding a bike for leisure or exercise", DifficultyLevel = 3, AverageTimeSpentPerWeek = 5.5, IsOutdoorActivity = true },
                new Hobby { Id = 2, Name = "Painting", Description = "Creating art using paint", DifficultyLevel = 4, AverageTimeSpentPerWeek = 3.0, IsOutdoorActivity = false },
                new Hobby { Id = 3, Name = "Hiking", Description = "Walking trails in nature", DifficultyLevel = 4, AverageTimeSpentPerWeek = 6.0, IsOutdoorActivity = true }
            );

            modelBuilder.Entity<Exercise>().HasData(
                new Exercise { Id = 1, Name = "Pushups", Description = "Using your arms to move your body", Repetitions = 10, Sets = 3, RequiresEquipment = false },
                new Exercise { Id = 2, Name = "Squats", Description = "Squatting with legs", Repetitions = 8, Sets = 2, RequiresEquipment = false },
                new Exercise { Id = 3, Name = "BicepCurl", Description = "Curling dumbbells for biceps", Repetitions = 12, Sets = 4, RequiresEquipment = true }

            modelBuilder.Entity<BoardGames>().HasData(
               new BoardGames { Id = 1, Name = "Uno", Description = "Playing till no more cards in hand", DifficultyLevel = 1, AveragePlayTime = 0.15},
               new BoardGames { Id = 2, Name = "Monopoly", Description = "Buy all the properties you can and bankrupt your friends", DifficultyLevel = 3, AveragePlayTime = 3.5},
               new BoardGames { Id = 3, Name = "Dungeons and Dragons", Description = "Role playing board game to play with friends", DifficultyLevel = 5, AveragePlayTime = 8760.0}
            );
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, FullName = "Heather Gibson", Birthdate = DateTime.Parse("6/14/1975"), CollegeProgram = "IT", YearInProgram = "1" }
                new TeamMember { Id = 2, FullName = "Cage Wellman", Birthdate = DateTime.Parse("06/11/2002"), CollegeProgram = "IT", YearInProgram = "3" }

            );
        }


    }
}
