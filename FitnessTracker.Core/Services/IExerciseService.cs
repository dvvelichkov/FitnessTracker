using FitnessTracker.Core.ViewModels.Exercises;
using System.Collections.Generic;

namespace FitnessTracker.Core.Services
{
    public interface IExerciseService
    {
        AllExercisesQueryModel All(string searchCriteria, ExerciseSorting sorting, IEnumerable<ExerciseListViewModel> exercises);
        IEnumerable<ExerciseListViewModel>Exercises();
    }
}
