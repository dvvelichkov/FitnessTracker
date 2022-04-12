using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Infrastructure.Constants
{
    public class DataConstants
    {
            //Exercise
        
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
        

            //PersonalRecord
        
            public const int PersonalRecordExerciseNameMinLength = 5;
            public const int PersonalRecordExerciseNameMaxLength = 60;


            //FitnessTip

            public const int FitnessTipNameMaxLength = 60;
            public const int FitnessTipDescriptionMaxLength = 400;


            //FitnessProgram

            public const int FitnessProgramNameMinLength = 5;
            public const int FitnessProgramNameMaxLength = 50;
 

            //ProgramDay
        
            public const int ProgramDayNameMinLength = 1;
            public const int ProgramDayNameMaxLength = 20;
       

            //Supplement
        
            public const int SupplementNameMinLength = 4;
            public const int SupplementNameMaxLength = 60;
            public const int SupplementDescriptionMinLength = 10;
            public const int SupplementDescriptionMaxLength = 500;
        

            //SupplementationPlan
        
            public const int SupplementationPlanNameMinLength = 1;
            public const int SupplementationPlanNameMaxLength = 50;
        

            public const int UserFullNameMinLength = 4;
            public const int UserFullNameMaxLength = 30;
            public const int UserPasswordMinLength = 4;
            public const int UserPasswordMaxLength = 20;

    }
}
