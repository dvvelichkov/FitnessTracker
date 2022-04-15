using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Extensions;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.PersonalRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Controllers
{
    [Authorize]
    public class PersonalRecordsController : Controller
    {
        private readonly IRepository repo;
        public PersonalRecordsController(IRepository _repo)
        {
            this.repo = _repo;
        }
        public IActionResult Add()
        {
            return View(new AddPersonalRecordViewModel
            {
                Exercises = this.GetExerciseNames()
            });
        }

        [Authorize]
        public IActionResult All()
        {
            var personalRecords = this.repo.All<PersonalRecord>()
                .OrderByDescending(x=> x.Id)
                .Select(x => new PersonalRecordListViewModel
                {
                    Id = x.Id,
                    Name = x.Exercise.Name,
                    Weight = x.Weight
                })
                .ToList();

            return View(personalRecords);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddPersonalRecordViewModel personalRecord)
        {
            if(!this.repo.All<Exercise>().Any(x=> x.Id == personalRecord.ExerciseId))
            {
                this.ModelState.AddModelError(nameof(personalRecord.ExerciseId), "Exercise does not exist.");
            }
            if (!ModelState.IsValid)
            {
                personalRecord.Exercises = this.GetExerciseNames();
                return View(personalRecord);
            }

            var existingRecordUserId = this.repo.All<PersonalRecord>().Where(x => x.UserId == this.User.GetId())
                .Select(x => x.ExerciseId).First();

            if (existingRecordUserId == personalRecord.ExerciseId)
            {
                this.ModelState.AddModelError(nameof(personalRecord.ExerciseId),
                    "There is a personal record for that exercise already. Please edit it instead.");
                personalRecord.Exercises = this.GetExerciseNames();
                return View(personalRecord);
            }

                var personalRecordData = new PersonalRecord
                {
                    ExerciseId = personalRecord.ExerciseId,
                    Weight = personalRecord.Weight,
                    UserId = this.User.GetId()
                };
                repo.Add(personalRecordData);
                repo.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<PersonalRecordExerciseViewModel> GetExerciseNames()
        {
           return this.repo.All<Exercise>()
                .Select(x => new PersonalRecordExerciseViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();
        }
    }
}
