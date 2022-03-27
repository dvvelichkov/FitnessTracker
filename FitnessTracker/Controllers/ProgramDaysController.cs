using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.ProgramDays;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class ProgramDaysController : Controller
    {
        private readonly IRepository repo;

        public ProgramDaysController(IRepository _repo)
        {
            this.repo = _repo;
        }

        public IActionResult Create()
        {
            return View(new CreateProgramDayViewModel
            {
                Exercises = this.GetExerciseNames()
            });
        }

        [HttpPost]
        public IActionResult Create(CreateProgramDayViewModel programDay)
        {
            return View();
        }
        private IEnumerable<ProgramDayExerciseViewModel> GetExerciseNames()
        {
            return this.repo.All<Exercise>()
                 .Select(x => new ProgramDayExerciseViewModel
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
