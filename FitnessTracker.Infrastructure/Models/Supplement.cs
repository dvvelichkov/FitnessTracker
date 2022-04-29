using FitnessTracker.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Infrastructure
{
    public class Supplement
    {
        public Supplement()
        {
          
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SupplementNameMaxLength)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        [MaxLength(SupplementDescriptionMaxLength)]
        public string Description { get; set; }
        public string Quantity { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("SupplementationPlan")]
        public int? SupplementationPlanId { get; set; }
    }
}
