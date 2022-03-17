using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Infrastructure.Models
{
    public class FitnessProgram
    {
        public FitnessProgram()
        {
            this.Exercises = new List<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FitnessProgramNameMaxLength)]
        public string Name { get; set; }

        [ForeignKey("Exercise")]
        public int ExerciseId { get; set; }
        public List<Exercise> Exercises { get; set; }
        public string ProgramDay { get; set; }
        public int ExerciseSets { get; set; }
        public int ExerciseReps { get; set; }
        public string ExerciseWeight { get; set; }

    }
}
