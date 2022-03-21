using FitnessTracker.Models.Exercises;
using FitnessTracker.Models.Infrastructure;

namespace FitnessTracker.Models.FitnessPrograms
{
    public class CreateFitnessProgramViewModel
    {
        public string Name { get; init; }
        public string ProgramDay { get; init; }
        public int ExerciseId { get; set; }
        public IEnumerable<ExerciseNameViewModel> Exercises { get; set; }
    }
}
