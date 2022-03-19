using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Models.Exercises;
using FitnessTracker.Models.FitnessPrograms;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class FitnessProgramsController : Controller
    {
        private readonly FitnessTrackerDbContext data;

        public FitnessProgramsController(FitnessTrackerDbContext _data)
        {
            this.data = _data;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreateFitnessProgramViewModel fitnessProgram)
        {
            return View();
        }

        //private IEnumerable<ExerciseNameViewModel> GetExerciseNames()
        //{
        //    this.data
                
        //}
    }
}
