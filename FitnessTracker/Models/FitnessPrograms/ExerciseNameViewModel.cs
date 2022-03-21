using FitnessTracker.Models.Infrastructure;

namespace FitnessTracker.Models.FitnessPrograms
{
    public class ExerciseNameViewModel
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseSets { get; set; }
        public int ExerciseReps { get; set; }
        public string ExerciseWeight { get; set; }
    }
}
