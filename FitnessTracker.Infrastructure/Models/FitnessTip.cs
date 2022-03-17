using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;

namespace FitnessTracker.Models.Infrastructure
{
    public class FitnessTip
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FitnessTipNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(FitnessTipDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
