using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Infrastructure.Models
{
    public class ProgramDay
    {
        public ProgramDay()
        {
            this.Exercises = new List<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProgramDayNameMaxLength)]
        public string Name { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
