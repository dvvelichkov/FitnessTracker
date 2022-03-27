namespace FitnessTracker.Models.ProgramDays
{
    public class CreateProgramDayViewModel
    {
        public string Name { get; set; }
        public int ExerciseId { get; init; }
        public IEnumerable<ProgramDayExerciseViewModel> Exercises { get; set; }
    }
}
