using FitnessTracker.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Infrastructure
{
    public class PersonalRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PersonalRecordExerciseNameMaxLength)]
        public string ExerciseName { get; set; }
        public string Weight { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
