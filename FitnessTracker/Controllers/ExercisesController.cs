using FitnessTracker.Models.Exercises;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class ExercisesController : Controller
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
