using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Infrastructure;

namespace FitnessTracker.Models.ProgramDays
{
    public class ProgramDayExerciseViewModel
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseSets { get; set; }
        public int ExerciseReps { get; set; }
        public string ExerciseWeight { get; set; }
    }
}
