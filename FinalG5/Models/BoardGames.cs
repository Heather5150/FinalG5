namespace FinalG5.Models
{
    public class BoardGames
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the Hobby (e.g., Painting, Running)
        public string Description { get; set; } // Brief Description of the Hobby
        public int DifficultyLevel { get; set; } // Difficulty Level (e.g., 1 to 5 scale)
        public double AveragePlayTime { get; set; } // Average hours per week spent on the Hobby
    }
}
