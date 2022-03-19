using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Infrastructure.Models
{
    public class SupplementationPlan
    {
        public SupplementationPlan()
        {
            this.Supplements = new List<Supplement>();
            this.SupplementsInSupplementationPlans = new HashSet<SupplementInSupplementationPlan>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SupplementationPlanNameMaxLength)]
        public string Name { get; set; }
        public List<Supplement> Supplements { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<SupplementInSupplementationPlan> SupplementsInSupplementationPlans { get; set; }
    }
}
