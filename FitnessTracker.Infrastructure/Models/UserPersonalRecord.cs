using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class UserPersonalRecord
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int PersonalRecordId { get; set; }
        public PersonalRecord PersonalRecord { get; set; }

        
    }
}
