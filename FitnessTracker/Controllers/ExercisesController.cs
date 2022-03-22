using FitnessTracker.Models.Exercises;
using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Models.Infrastructure;

namespace FitnessTracker.Controllers
{
    public class ExercisesController : Controller
    {
        //private readonly IRepository repo;

        private readonly FitnessTrackerDbContext data;

        public ExercisesController(FitnessTrackerDbContext _data)
        {
            this.data = _data;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(AddExerciseViewModel exercise)
        {
            var existingExercise = this.data.Exercises.ToList().FirstOrDefault();

            if (existingExercise != null)
            {
                if (existingExercise.Name.ToLower() == exercise.Name.ToLower())
                {
                    this.ModelState.AddModelError(nameof(exercise.Name), "This exercise already exists!");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            Exercise exerciseData = new Exercise()
            {
                Name = exercise.Name,
                Description = exercise.Description,
                ImageUrl = exercise.ImageUrl,
                ExerciseSets = exercise.ExerciseSets,
                ExerciseReps = exercise.ExerciseReps,
                ExerciseWeight = exercise.ExerciseWeight
            };

            data.Add(exerciseData);
            data.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
