using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Exercises;
using FitnessTracker.Models.FitnessPrograms;
using FitnessTracker.Models.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class FitnessProgramsController : Controller
    {
        private readonly IRepository repo;
        //private readonly FitnessTrackerDbContext data;

        public FitnessProgramsController(IRepository _repo)
        {
            this.repo = _repo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var item = repo.All<Exercise>().ToList();

            CreateFitnessProgramViewModel fitnessProgram = new CreateFitnessProgramViewModel();
            fitnessProgram.AvailableExercises = item.Select(x => new CheckBoxItem
            {
                Id = x.Id,
                Title = x.Name,
                Sets = x.ExerciseSets.ToString(),
                Reps = x.ExerciseReps.ToString(),
                Weight = x.ExerciseWeight,

                IsChecked = false
            }).ToList();

            return View(fitnessProgram);
        }

        [HttpPost]
        public IActionResult Create(CreateFitnessProgramViewModel fitProgramData, FitnessProgram fitProgram, ExerciseInFitnessProgram exInProgram)
        {
            FitnessProgram fitnessProgram = new FitnessProgram();
            {
                fitProgram.Name = fitProgramData.Name;
                fitProgram.ProgramDay = fitProgramData.ProgramDay;
                int fitnessProgramId = fitProgram.Id;

            }

            foreach (var item in fitProgramData.AvailableExercises)
            {
                if(item.IsChecked == true)
                {
                    fitnessProgram.ExercisesInFitnessPrograms.Add(new ExerciseInFitnessProgram
                    {
                        FitnessProgramId = fitProgram.Id,
                        ExerciseId = item.Id,
                        ProgramDay = fitProgram.ProgramDay
                    });
                }
            }
            return null;
        }
    }
}
