using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Exercises
{
    public class AddExerciseViewModel
    {
        [Required]
        [StringLength(ExerciseNameMaxLength, MinimumLength=ExerciseNameMinLength, ErrorMessage = "The name must be text between {2} and {1} characters long.")]
        public string Name { get; set; }

        [StringLength(ExerciseDescriptionMaxLength, MinimumLength=ExerciseDescriptionMinLength, ErrorMessage = "The description must be text between {2} and {1} characters long.")]
        public string Description { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Range(ExerciseSetsMinValue, ExerciseSetsMaxValue, ErrorMessage = "The sets count must be between {1} and {2}.")]
        public int ExerciseSets { get; set; }

        [Range(ExerciseRepsMinValue, ExerciseRepsMaxValue, ErrorMessage = "The reps count must be between {1} and {2}.")]
        public int ExerciseReps { get; set; }

        [StringLength(ExerciseWeightMaxLength, MinimumLength=ExerciseWeightMinLength, ErrorMessage = "Please write between {2} and {1} characters.")]
        public string ExerciseWeight { get; set; }
    }
}
