using System.Collections.Generic;

namespace FitnessTracker.Models.SupplementationPlans
{
    public class SupplPlanListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SupplPlanSupplementViewModel> Supplements { get; set; }
    }
}
