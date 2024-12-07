﻿
using FinalG5.Models;
using Microsoft.EntityFrameworkCore;


namespace FinalG5.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<BoardGames> BoardGames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Name = "Cycling", Description = "Riding a bike for leisure or exercise", DifficultyLevel = 3, AverageTimeSpentPerWeek = 5.5, IsOutdoorActivity = true },
                new Hobby { Id = 2, Name = "Painting", Description = "Creating art using paint", DifficultyLevel = 4, AverageTimeSpentPerWeek = 3.0, IsOutdoorActivity = false },
                new Hobby { Id = 3, Name = "Hiking", Description = "Walking trails in nature", DifficultyLevel = 4, AverageTimeSpentPerWeek = 6.0, IsOutdoorActivity = true }
            );
            modelBuilder.Entity<BoardGames>().HasData(
               new BoardGames { Id = 1, Name = "Uno", Description = "Playing till no more cards in hand", DifficultyLevel = 1, AveragePlayTime = 0.15},
               new BoardGames { Id = 2, Name = "Monopoly", Description = "Buy all the properties you can and bankrupt your friends", DifficultyLevel = 3, AveragePlayTime = 3.5},
               new BoardGames { Id = 3, Name = "Dungeons and Dragons", Description = "Role playing board game to play with friends", DifficultyLevel = 5, AveragePlayTime = 8760.0}
           );
        }


    }
}
