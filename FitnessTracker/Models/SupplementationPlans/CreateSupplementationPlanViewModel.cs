using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.SupplementationPlans
{
    public class CreateSupplementationPlanViewModel
    {
        [Required]
        [StringLength(SupplementationPlanNameMaxLength, MinimumLength = SupplementationPlanNameMinLength,
            ErrorMessage = "The name must be between {2} and {1} characters.")]
        public string Name { get; set; }
        public int SupplementId { get; init; }

        [BindProperty]
        public List<SupplPlanSupplementViewModel> Supplements { get; set; } = new List<SupplPlanSupplementViewModel>();
    }
}
