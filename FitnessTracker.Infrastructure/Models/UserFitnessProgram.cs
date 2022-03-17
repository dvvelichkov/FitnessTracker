using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class UserFitnessProgram
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int FitnessProgramId { get; set; }
        public FitnessProgram FitnessProgram { get; set; }
            
    }
}
