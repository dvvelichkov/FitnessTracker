using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class ExerciseController : Controller
    {
        public IActionResult Exercise()
        {
            return View();
        }
    }
}
