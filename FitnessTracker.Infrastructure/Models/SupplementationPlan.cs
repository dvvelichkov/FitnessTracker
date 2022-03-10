using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class SupplementationPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Supplement")]
        public int SupplementId { get; set; }
        public List<Supplement> Supplements { get; set; }
    }
}
