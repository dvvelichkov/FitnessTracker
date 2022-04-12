using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Models.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.PersonalRecords = new List<PersonalRecord>();
            this.SupplementationPlans = new List<SupplementationPlan>();
            this.ProgramDays = new List<ProgramDay>();
        }
        public IEnumerable<PersonalRecord> PersonalRecords { get; set; }
        public IEnumerable<SupplementationPlan> SupplementationPlans { get; set; }
        public IEnumerable<ProgramDay> ProgramDays { get; set; }
    }
}
