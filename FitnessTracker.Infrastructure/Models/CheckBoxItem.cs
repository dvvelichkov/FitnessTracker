using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class CheckBoxItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Sets { get; set; }
        public string Reps { get; set; }
        public string Weight { get; set; }
        public bool IsChecked { get; set; }
    }
}
