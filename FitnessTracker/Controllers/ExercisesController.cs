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
        private readonly IRepository repo;

        public ExercisesController(IRepository _repo)
        {
            this.repo = _repo;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Add(AddExerciseViewModel exercise)
        {
            var existingExercise = this.repo.All<Exercise>().ToList();

            if (existingExercise.Any(x => x.Name.ToLower() == exercise.Name.ToLower()))
            {
                this.ModelState.AddModelError(nameof(exercise.Name), "This exercise already exists!");
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

            repo.Add(exerciseData);
            repo.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
