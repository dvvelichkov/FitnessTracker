using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Constants
{
    public class DataConstants
    {
        public class Exercise
        {
            public const int ExerciseNameMinLength = 5;
            public const int ExerciseNameMaxLength = 60;
            public const int ExerciseSetsMinValue = 1;
            public const int ExerciseSetsMaxValue = 200;
            public const int ExerciseRepsMinValue = 1;
            public const int ExerciseRepsMaxValue = 200;
            public const int ExerciseWeightMinLength = 1;
            public const int ExerciseWeightMaxLength = 15;
            public const int ExerciseDescriptionMinLength = 10;
            public const int ExerciseDescriptionMaxLength = 600;
        }

        public class PersonalRecord
        {
            public const int PersonalRecordExerciseNameMinLength = 5;
            public const int PersonalRecordExerciseNameMaxLength = 60;
        }

        public class FitnessTip
        {
            public const int FitnessTipNameMaxLength = 60;
            public const int FitnessTipDescriptionMaxLength = 400;
        }

        public class FitnessProgram
        {
            public const int FitnessProgramNameMinLength = 5;
            public const int FitnessProgramNameMaxLength = 50;
        }

        public class ProgramDay
        {
            public const int ProgramDayNameMinLength = 1;
            public const int ProgramDayNameMaxLength = 20;
        }

        public class Supplement
        {
            public const int SupplementNameMinLength = 4;
            public const int SupplementNameMaxLength = 60;
            public const int SupplementDescriptionMinLength = 10;
            public const int SupplementDescriptionMaxLength = 500;
        }

        public class SupplementationPlan
        {
            public const int SupplementationPlanNameMinLength = 1;
            public const int SupplementationPlanNameMaxLength = 50;
        }
    }
}
