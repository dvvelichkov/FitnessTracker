using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Core.ViewModels.Exercises
{
    public class AllExercisesQueryModel
    {
        [Display(Name = "Search")]
        public string SearchCriteria { get; set; }
        public ExerciseSorting Sorting { get; set; }
        public IEnumerable<ExerciseListViewModel> Exercises { get; set; }
    }
}
