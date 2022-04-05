namespace FitnessTracker.Models.ProgramDays
{
    public class ProgramDayListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProgramDayExerciseViewModel> Exercises { get; set; }
    }
}
