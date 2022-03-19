using FitnessTracker.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Infrastructure
{
    public class Exercise
    {
        public Exercise()
        {
            this.ExercisesInFitnessPrograms = new HashSet<ExerciseInFitnessProgram>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ExerciseNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(ExerciseDescriptionMaxLength)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ExerciseSets { get; set; }
        public int ExerciseReps { get; set; }
        public string ExerciseWeight { get; set; }
        public ICollection<ExerciseInFitnessProgram> ExercisesInFitnessPrograms { get; set; }
    }
}