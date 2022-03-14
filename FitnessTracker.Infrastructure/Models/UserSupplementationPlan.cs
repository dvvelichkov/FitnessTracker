using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class UserSupplementationPlan
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SupplementationPlanId { get; set; }
        public SupplementationPlan SupplementationPlan { get; set; }
    }
}
