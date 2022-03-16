using FitnessTracker.Exercises.Models;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class ExercisesController : BaseController
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(AddExerciseViewModel exercise)
        {
            return View();
        }
    }
}
