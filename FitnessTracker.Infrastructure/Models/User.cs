using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.PersonalRecords = new List<PersonalRecord>();
            this.ProgramDays = new List<ProgramDay>();
        }

        [MaxLength(UserFullNameMaxLength)]
        public string FullName { get; set; }
        public IEnumerable<PersonalRecord> PersonalRecords { get; set; }
        public SupplementationPlan SupplementationPlan { get; set; }
        public IEnumerable<ProgramDay> ProgramDays { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<Supplement> Supplements { get; set; }
    }
}
