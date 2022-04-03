using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models.Supplements
{
    public class AllSupplementsQueryModel
    {
        [Display(Name = "Search")]
        public string SearchCriteria { get; set; }
        public SupplementSorting Sorting { get; set; }
        public IEnumerable<SupplementListViewModel> Supplements { get; set; }
    }
}
