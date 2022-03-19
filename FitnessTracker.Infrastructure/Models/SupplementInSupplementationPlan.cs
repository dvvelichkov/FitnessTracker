using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class SupplementInSupplementationPlan
    {
        public int SupplementId { get; set; }
        public Supplement Supplement { get; set; }
        public int SupplementationPlanId { get; set; }
        public SupplementationPlan SupplementationPlan { get; set; }
    }
}
