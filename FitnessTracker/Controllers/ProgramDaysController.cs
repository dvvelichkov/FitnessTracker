using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Models;
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
            if(!ModelState.IsValid)
            {
                programDay.Exercises = this.GetExerciseNames();
                return View(programDay);
            }
            var programDayData = new ProgramDay
            {
                Name = programDay.Name
            };

            foreach (var option in repo.All<Exercise>())
            {
                if(programDay.IsChecked)
                {
                    programDayData.Exercises.Add(new Exercise
                    {
                        Name = option.Name,
                        Description = option.Description,
                        ImageUrl = option.ImageUrl,
                        ExerciseSets = option.ExerciseSets,
                        ExerciseReps = option.ExerciseReps,
                        ExerciseWeight = option.ExerciseWeight
                    });
                }
            }
            repo.Add(programDayData);
            repo.SaveChanges();

            return RedirectToAction("Index", "Home");

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
