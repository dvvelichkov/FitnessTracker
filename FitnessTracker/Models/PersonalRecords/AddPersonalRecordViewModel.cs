using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.PersonalRecords
{
    public class AddPersonalRecordViewModel
    {
        [Required]
        [StringLength(ExerciseWeightMaxLength, MinimumLength = ExerciseWeightMinLength,
            ErrorMessage = "Please write between {2} and {1} characters.")]
        public string Weight { get; init; }

        [Display(Name = "Exercise name")]
        public int ExerciseId { get; init; }
        public IEnumerable<PersonalRecordExerciseViewModel> Exercises { get; set; }
        public string UserId { get; set; }
    }
}
