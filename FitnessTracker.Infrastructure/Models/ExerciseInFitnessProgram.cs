using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class ExerciseInFitnessProgram
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int FitnessProgramId { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
    }
}
