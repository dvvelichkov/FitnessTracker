using FitnessTracker.Models.Infrastructure;
using System.Collections.Generic;

namespace FitnessTracker.Models.PersonalRecords
{
    public class EditPersonalRecordViewModel
    {
        public int Id { get; set; }
        public string Weight { get; init; }
        public int ExerciseId { get; init; }
        public Exercise Exercise { get; set; }
        public string UserId { get; set; }
        public IEnumerable<PersonalRecordExerciseViewModel> Exercises { get; set; }
    }
}
