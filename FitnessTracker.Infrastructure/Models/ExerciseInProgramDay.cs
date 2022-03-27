using FitnessTracker.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Models
{
    public class ExerciseInProgramDay
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int ProgramDayId { get; set; }
        public ProgramDay ProgramDay { get; set; }

    }
}
