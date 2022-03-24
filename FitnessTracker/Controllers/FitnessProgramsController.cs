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
            this.repo= _repo;
        }
        public IActionResult Create()
        {
            return View(new CreateFitnessProgramViewModel
            {
                Exercises = this.GetExerciseNames()
            });
        }

        [HttpPost]

        public IActionResult Create(CreateFitnessProgramViewModel fitnessProgram)
        {
            if(!ModelState.IsValid)
            {
                return View(fitnessProgram);
            }

            FitnessProgram fitnessProgramData = new FitnessProgram
            {
                Name = fitnessProgram.Name,
                ProgramDay = fitnessProgram.ProgramDay
            };

            //repo.Add(fitnessProgramData);
            //repo.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ExerciseNameViewModel> GetExerciseNames()
        {
            return repo.All<Exercise>().Select(x => new ExerciseNameViewModel
            {
                Id = x.Id,
                ExerciseName = x.Name,
                ExerciseSets = x.ExerciseSets,
                ExerciseReps = x.ExerciseReps,
                ExerciseWeight = x.ExerciseWeight
            })
            .ToList();
        }

    }
}
