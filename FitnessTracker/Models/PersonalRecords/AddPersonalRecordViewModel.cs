using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.PersonalRecords
{
    public class AddPersonalRecordViewModel
    {
        [Required]
        [StringLength(PersonalRecordExerciseNameMaxLength, MinimumLength = PersonalRecordExerciseNameMinLength, ErrorMessage = "The name must be text between {2} and {1} characters long.")]
        public string ExerciseName { get; set; }

        [Required]
        [StringLength(ExerciseWeightMaxLength, MinimumLength = ExerciseWeightMinLength, ErrorMessage = "Please write between {2} and {1} characters.")]
        public string Weight { get; set; }
    }
}
