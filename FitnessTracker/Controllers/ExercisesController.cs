using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Core.Services;
using FitnessTracker.Core.ViewModels.Exercises;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using FitnessTracker.Infrastructure.Extensions;

namespace FitnessTracker.Controllers
{

    public class ExercisesController : Controller
    {
        private readonly IExerciseService exercises;
        private IRepository repo;

        public ExercisesController(IExerciseService _exercises, IRepository _repo)
        {
            this.exercises = _exercises;
            this.repo = _repo;
        }
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        public IActionResult All(AllExercisesQueryModel query)
        {
            var queryResult = this.exercises.All
                (
                query.SearchCriteria,
                query.Sorting,
                query.Exercises
                );

            query.SearchCriteria = queryResult.SearchCriteria;
            query.Sorting = queryResult.Sorting;
            query.Exercises = queryResult.Exercises;

            return View(query);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddExerciseViewModel exercise)
        {
            var existingExercise = this.repo.All<Exercise>()
                .Where(x => x.UserId == this.User.GetId())
                .ToList();

            if (existingExercise.Any(x=> x.Name.ToLower() == exercise.Name.ToLower()))
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
                ExerciseWeight = exercise.ExerciseWeight,
                UserId = this.User.GetId()
            };

            repo.Add(exerciseData);
            repo.SaveChanges();

            return RedirectToAction(nameof(All));

        }
    }
}
