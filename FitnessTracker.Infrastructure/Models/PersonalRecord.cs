using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Models.Infrastructure
{
    public class PersonalRecord
    {
        public int Id { get; set; }
        public string ExerciseName { get; set; }
        public int Weight { get; set; }
    }
}
