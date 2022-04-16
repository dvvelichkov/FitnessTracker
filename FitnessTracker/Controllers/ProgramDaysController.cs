using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Extensions;
using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.ProgramDays;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Controllers
{
    [Authorize]
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
                Exercises = this.GetExerciseNames().ToList()
            });
        }

        [Authorize]
        public IActionResult All()
        {

            var programDays = this.repo.All<ProgramDay>()
                .OrderByDescending(x => x.Id)
                .Select(x => new ProgramDayListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Exercises = x.Exercises.Select(x => new ProgramDayExerciseViewModel
                    {
                        Id = x.Id,
                        ExerciseName = x.Name,
                        ExerciseSets = x.ExerciseSets,
                        ExerciseReps = x.ExerciseReps,
                        ExerciseWeight = x.ExerciseWeight
                    })
                })
                .ToList();

            return View(programDays);
        }

        [Authorize]
        public IActionResult Mine()
        {

            var programDays = this.repo.All<ProgramDay>()
                .Where(x => x.UserId == this.User.GetId())
                .OrderByDescending(x => x.Id)
                .Select(x => new ProgramDayListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Exercises = x.Exercises.Select(x => new ProgramDayExerciseViewModel
                    {
                        Id = x.Id,
                        ExerciseName = x.Name,
                        ExerciseSets = x.ExerciseSets,
                        ExerciseReps = x.ExerciseReps,
                        ExerciseWeight = x.ExerciseWeight
                    })
                })
                .ToList();

            return View(programDays);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateProgramDayViewModel programDay)
        {
            if (!ModelState.IsValid)
            {
                programDay.Exercises = this.GetExerciseNames().ToList();
                return View(programDay);
            }

            var existingProgramDay = this.repo.All<ProgramDay>().Where(x => x.UserId == this.User.GetId())
                    .Select(x => x.Name).First();

            if (existingProgramDay.ToLower() == programDay.Name.ToLower())
            {
                this.ModelState.AddModelError(nameof(programDay.Name),
                    "You already have such program day! Please edit it instead.");

                programDay.Exercises = this.GetExerciseNames().ToList();
                return View(programDay);
            }


            var programDayData = new ProgramDay
            {
                Name = programDay.Name,
                UserId = this.User.GetId()
            };

            foreach (var option in programDay.Exercises)
            {
                if (option.IsChecked == true)
                {
                    var exercises = repo.All<Exercise>().ToList();
                    var exerciseToAdd = exercises.Where(x => x.Id == option.Id).FirstOrDefault();

                    programDayData.Exercises.Add(exerciseToAdd);
                }
            }
            repo.Add(programDayData);
            repo.SaveChanges();


            return RedirectToAction(nameof(All));

        }
        private IEnumerable<ProgramDayExerciseViewModel> GetExerciseNames()
        {
            return this.repo.All<Exercise>()
                 .Select(x => new ProgramDayExerciseViewModel
                 {
                     Id = x.Id,
                     ExerciseName = x.Name,
                     Description = x.Description,
                     ImageUrl = x.ImageUrl,
                     ExerciseSets = x.ExerciseSets,
                     ExerciseReps = x.ExerciseReps,
                     ExerciseWeight = x.ExerciseWeight
                 })
                 .ToList();
        }
    }
}
