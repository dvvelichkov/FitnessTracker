using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.ProgramDays
{
    public class CreateProgramDayViewModel
    {
        [Required]
        [StringLength(ProgramDayNameMaxLength, MinimumLength = ProgramDayNameMinLength,
            ErrorMessage = "The name must be between {2} and {1} characters.")]
        public string Name { get; set; }
        public int ExerciseId { get; init; }
        public IEnumerable<ProgramDayExerciseViewModel> Exercises { get; set; }
        public bool IsChecked { get; set; }
    }
}
