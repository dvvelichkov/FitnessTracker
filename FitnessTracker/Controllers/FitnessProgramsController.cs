using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Models.Exercises;
using FitnessTracker.Models.FitnessPrograms;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class FitnessProgramsController : Controller
    {
        //private readonly IRepository repo;
        private readonly FitnessTrackerDbContext data;

        public FitnessProgramsController(FitnessTrackerDbContext _data)
        {
            this.data= _data;
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
            return View();
        }

        private IEnumerable<ExerciseNameViewModel> GetExerciseNames()
        {
            return data.Exercises.Select(x => new ExerciseNameViewModel
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

    //public string ExerciseName { get; set; }
    //public int ExerciseSets { get; set; }
    //public int ExerciseReps { get; set; }
    //public string ExerciseWeight { get; set; }
}
