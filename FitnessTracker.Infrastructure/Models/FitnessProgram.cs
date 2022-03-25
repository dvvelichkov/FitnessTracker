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
            this.ExercisesInFitnessPrograms = new List<ExerciseInFitnessProgram>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FitnessProgramNameMaxLength)]
        public string Name { get; set; }
        public string ProgramDay { get; set; }
        public List<Exercise> Exercises { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<ExerciseInFitnessProgram> ExercisesInFitnessPrograms { get; set; }

    }
}
