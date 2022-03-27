using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Data;
using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Exercises;
using FitnessTracker.Models.FitnessPrograms;
using FitnessTracker.Models.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class FitnessProgramsController : Controller
    {
        private readonly IRepository repo;

        public FitnessProgramsController(IRepository _repo)
        {
            this.repo = _repo;
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    var item = repo.All<Exercise>().ToList();

        //    CreateFitnessProgramViewModel fitnessProgram = new CreateFitnessProgramViewModel();
        //    fitnessProgram.AvailableExercises = item.Select(x => new CheckBoxItem
        //    {
        //        Id = x.Id,
        //        Title = x.Name,
        //        IsChecked = false
        //    }).ToList();

        //    return View(fitnessProgram);
        //}

        //[HttpPost]
        //public IActionResult Create(CreateFitnessProgramViewModel fitProgram)
        //{
            //FitnessProgram fitProgramData = new FitnessProgram();
            //{
            //    fitProgramData.Name = fitProgram.Name;
            //    fitProgramData.ProgramDay = fitProgram.ProgramDay;

            //    foreach (var item in fitProgram.AvailableExercises)
            //    {

            //        if (item.IsChecked == true)
            //        {
            //            var exercises = repo.All<Exercise>().ToList();
            //            var exerciseToAdd = exercises.Where(x => x.Id == item.Id).FirstOrDefault();
            //            if (exerciseToAdd != null)
            //            {
            //                fitProgramData.Exercises.Add(exerciseToAdd);
            //                fitProgramData.ExercisesInFitnessPrograms.Add(new ExerciseInProgramDay
            //                {
            //                    ExerciseId = exerciseToAdd.Id,
            //                    ProgramDay = fitProgramData.ProgramDay,
            //                    FitnessProgramId = fitProgramData.Id,
            //                    FitnessProgram = fitProgramData,
            //                });
            //            }
            //        }
            //    }
            //}

            //repo.Add(fitProgramData);
            //repo.SaveChanges();
            //return RedirectToAction("Index", "Home");
        //}
    }
}
