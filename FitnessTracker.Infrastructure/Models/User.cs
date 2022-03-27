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
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public IEnumerable<PersonalRecord> PersonalRecords { get; set; }
        public IEnumerable<SupplementationPlan> SupplementationPlans { get; set; }
        public IEnumerable<FitnessProgram> FitnessPrograms { get; set; }
    }
}
