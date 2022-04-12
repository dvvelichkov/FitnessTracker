using FitnessTracker.Infrastructure.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Infrastructure
{
    public class Exercise
    {
        public Exercise()
        {
            this.PersonalRecords = new List<PersonalRecord>();
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
        public IEnumerable<PersonalRecord> PersonalRecords { get; set; }
        public IEnumerable<ProgramDay> ProgramDays { get; set; }
    }
}