using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class UserPersonalRecord
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("PersonalRecord")]
        public int PersonalRecordId { get; set; }
        public PersonalRecord PersonalRecord { get; set; }

        
    }
}
