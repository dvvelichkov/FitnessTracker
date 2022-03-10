using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FitnessTracker.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
    }
}
