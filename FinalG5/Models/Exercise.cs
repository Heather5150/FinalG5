namespace FinalG5.Models
{
    public class Exercise
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // Name of the Exercise (e.g., jumping jacks, pushups)
        public string Description { get; set; } // Brief Description of the exercise
        public int Repetitions { get; set; } // The amount of repetitions (e.g., 8, 10, 12)
        public int Sets { get; set; } // The amount of sets of the exercise done
        public bool RequiresEquipment { get; set; } // Indicates if the exercise needs equipment
    }
}
