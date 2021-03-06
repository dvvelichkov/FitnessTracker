using System.ComponentModel.DataAnnotations;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Supplements
{
    public class AddSupplementViewModel
    {
        [Required]
        [StringLength(SupplementNameMaxLength, MinimumLength = SupplementNameMinLength,
            ErrorMessage = "The supplement name must be text between {2} and {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [StringLength(SupplementDescriptionMaxLength, MinimumLength = SupplementDescriptionMinLength,
            ErrorMessage = "The supplement description must be text between {2} and {1} characters long.")]
        public string Description { get; set; }

        [Required]
        public string Quantity { get; set; }
        public string UserId { get; set; }
    }
}
