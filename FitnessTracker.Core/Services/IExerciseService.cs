using FitnessTracker.Core.ViewModels.Exercises;

namespace FitnessTracker.Core.Services
{
    public interface IExerciseService
    {
        AllExercisesQueryModel All(string searchCriteria, ExerciseSorting sorting, IEnumerable<ExerciseListViewModel> exercises);
        IEnumerable<ExerciseListViewModel>Exercises();
    }
}
