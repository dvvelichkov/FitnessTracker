using FitnessTracker.Models.Exercises;

namespace FitnessTracker.Models.FitnessPrograms
{
    public class CreateFitnessProgramViewModel
    {
        public string Name { get; init; }
        public string ProgramDay { get; init; }
        public int ExerciseSets { get; init; }
        public int ExerciseReps { get; init; }
        public string ExerciseWeight { get; init; }
        public int ExerciseId { get; set; }
        public IEnumerable<AddExerciseViewModel> Exercises { get; set; }
    }
}
