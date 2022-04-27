using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Extensions;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.PersonalRecords;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Controllers
{

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

        [Authorize]
        public IActionResult Mine()
        {
            var personalRecords = this.repo.All<PersonalRecord>()
                .Where(x=> x.UserId == this.User.GetId())
                .OrderByDescending(x => x.Id)
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

            var existingRecord = this.repo.All<PersonalRecord>()
                .Where(x => x.UserId == this.User.GetId())
                .ToList();

            if (existingRecord.Any(x=> x.ExerciseId == personalRecord.ExerciseId))
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

            return RedirectToAction("Mine", "PersonalRecords");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var personalRecord = this.Details(id);

            if(personalRecord.UserId != this.User.GetId())
            {
                return BadRequest();
            }

            return View(new AddPersonalRecordViewModel
            {
                ExerciseId = personalRecord.ExerciseId,
                Weight = personalRecord.Weight,
                UserId = personalRecord.UserId,
                Exercises = this.GetExerciseNames()
            });
        }

        [HttpPost]
        [Authorize]    
        public IActionResult Edit(EditPersonalRecordViewModel personalRecord)
        {
            if (!this.repo.All<Exercise>().Any(x => x.Id == personalRecord.ExerciseId))
            {
                this.ModelState.AddModelError(nameof(personalRecord.ExerciseId), "Exercise does not exist.");
            }
            if (!ModelState.IsValid)
            {
                personalRecord.Exercises = this.GetExerciseNames();
                return View(personalRecord);
            }

            var personalRecordData = this.repo.All<PersonalRecord>()
                .Where(x=> x.UserId == this.User.GetId())
                .First(x=> x.ExerciseId == personalRecord.ExerciseId);

            if(personalRecordData.UserId != this.User.GetId())
            {
                return BadRequest();
            }

            personalRecordData.ExerciseId = personalRecord.ExerciseId;
            personalRecordData.Weight = personalRecord.Weight;

            repo.SaveChanges();
            return RedirectToAction("Mine", "PersonalRecords");
            
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

        public EditPersonalRecordViewModel Details(int id)
        {
            return this.repo.All<PersonalRecord>()
                .Where(x=> x.Id == id)
                .Select(x => new EditPersonalRecordViewModel
                {
                    Id = x.Id,
                    ExerciseId = x.ExerciseId,
                    Weight = x.Weight,
                    UserId = x.UserId,
                    Exercise = x.Exercise
                })
                .FirstOrDefault();
        }
    }
}
