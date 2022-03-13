using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class UserFitnessProgram
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public int FitnessProgramId { get; set; }
        public FitnessProgram fitnessProgram { get; set; }
            
    }
}
