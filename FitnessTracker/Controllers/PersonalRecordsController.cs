﻿using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.PersonalRecords;
using Microsoft.AspNetCore.Mvc;

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

            var personalRecordData = new PersonalRecord
            {
                ExerciseId = personalRecord.ExerciseId,
                Weight = personalRecord.Weight,
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
