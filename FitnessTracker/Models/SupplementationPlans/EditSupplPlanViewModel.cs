using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FitnessTracker.Models.SupplementationPlans
{
    public class EditSupplPlanViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SupplementId { get; init; }
        public string UserId { get; set; }

        [BindProperty]
        public List<SupplPlanSupplementViewModel> Supplements { get; set; } = new List<SupplPlanSupplementViewModel>();
    }
}
