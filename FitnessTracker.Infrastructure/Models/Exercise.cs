using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Infrastructure
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(ExerciseDescriptionMaxLength)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}