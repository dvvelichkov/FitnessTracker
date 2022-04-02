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

        public IActionResult All(string searchCriteria, ExerciseSorting sorting)
        {
            var exerciseQuery = this.repo.All<Exercise>().AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchCriteria))
            {
                exerciseQuery = exerciseQuery
                    .Where(x=> x.Name.ToLower().Contains(searchCriteria.ToLower()));
            }

            exerciseQuery = sorting switch
            {
                ExerciseSorting.DateCreated => exerciseQuery.OrderByDescending(x => x.Id),
                ExerciseSorting.Name => exerciseQuery.OrderBy(x=> x.Name),
                _ => exerciseQuery.OrderByDescending(x => x.Id)
            };

            var exercises = exerciseQuery               
                .Select(x => new ExerciseListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                })
                .ToList();

            return View(new AllExercisesQueryModel
            {
                Exercises = exercises,
                SearchCriteria = searchCriteria,
                Sorting = sorting
            });
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

            return RedirectToAction(nameof(All));

        }
    }
}
