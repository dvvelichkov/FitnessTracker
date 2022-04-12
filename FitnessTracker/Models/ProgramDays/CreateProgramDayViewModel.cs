using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [BindProperty]
        public List<ProgramDayExerciseViewModel> Exercises { get; set; } = new List<ProgramDayExerciseViewModel>();
    }
}
