namespace FinalG5.Models
{
    public class Hobby
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the Hobby (e.g., Painting, Running)
        public string Description { get; set; } // Brief Description of the Hobby
        public int DifficultyLevel { get; set; } // Difficulty Level (e.g., 1 to 5 scale)
        public double AverageTimeSpentPerWeek { get; set; } // Average hours per week spent on the Hobby
        public bool IsOutdoorActivity { get; set; } // Indicates if the Hobby is typically outdoors
    }
}
