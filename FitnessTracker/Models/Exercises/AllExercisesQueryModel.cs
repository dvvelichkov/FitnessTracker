using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models.Exercises
{
    public class AllExercisesQueryModel
    {
        [Display(Name = "Search")]
        public IEnumerable<string> SearchCriteria { get; set; }
        public ExerciseSorting Sorting { get; set; }
        public IEnumerable<ExerciseListViewModel> Exercises { get; set; }
    }
}
