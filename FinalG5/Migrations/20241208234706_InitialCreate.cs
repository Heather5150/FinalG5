using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalG5.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    AveragePlayTime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    AverageTimeSpentPerWeek = table.Column<double>(type: "float", nullable: false),
                    IsOutdoorActivity = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeProgram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearInProgram = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BoardGames",
                columns: new[] { "Id", "AveragePlayTime", "Description", "DifficultyLevel", "Name" },
                values: new object[,]
                {
                    { 1, 0.14999999999999999, "Playing till no more cards in hand", 1, "Uno" },
                    { 2, 3.5, "Buy all the properties you can and bankrupt your friends", 3, "Monopoly" },
                    { 3, 8760.0, "Role playing board game to play with friends", 5, "Dungeons and Dragons" }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "AverageTimeSpentPerWeek", "Description", "DifficultyLevel", "IsOutdoorActivity", "Name" },
                values: new object[,]
                {
                    { 1, 5.5, "Riding a bike for leisure or exercise", 3, true, "Cycling" },
                    { 2, 3.0, "Creating art using paint", 4, false, "Painting" },
                    { 3, 6.0, "Walking trails in nature", 4, true, "Hiking" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Birthdate", "CollegeProgram", "FullName", "YearInProgram" },
                values: new object[] { 1, new DateTime(1975, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Heather Gibson", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGames");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "TeamMembers");
        }
    }
}
