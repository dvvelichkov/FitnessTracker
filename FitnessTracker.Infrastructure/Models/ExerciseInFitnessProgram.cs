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
        public int Id { get; set; }
        public string ProgramDay { get; set; }
        public int ProgramDayId { get; set; }
        public int ExerciseId { get; set; }
        public List<Exercise> Exercises { get; set; }
        public int FitnessProgramId { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
    }
}
