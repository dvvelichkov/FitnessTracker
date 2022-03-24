﻿using FitnessTracker.Models.Exercises;
using FitnessTracker.Models.Infrastructure;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.FitnessPrograms
{
    public class CreateFitnessProgramViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(FitnessProgramNameMaxLength, MinimumLength = FitnessProgramNameMinLength, ErrorMessage = "The name must be text between {2} and {1} characters long.")]
        public string Name { get; init; }

        [Required]
        public string ProgramDay { get; init; }
        public int ExerciseId { get; set; }
        public IEnumerable<ExerciseNameViewModel> Exercises { get; set; }
    }
}