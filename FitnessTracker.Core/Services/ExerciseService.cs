using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Core.ViewModels.Exercises;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Core.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IRepository repo;

        public ExerciseService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public AllExercisesQueryModel All(string searchCriteria, ExerciseSorting sorting, IEnumerable<ExerciseListViewModel> exercises)
        {
            var exerciseQuery = this.repo.All<Exercise>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchCriteria))
            {
                exerciseQuery = exerciseQuery
                    .Where(x => x.Name.ToLower().Contains(searchCriteria.ToLower()));
            }

            exerciseQuery = sorting switch
            {
                ExerciseSorting.DateCreated => exerciseQuery.OrderByDescending(x => x.Id),
                ExerciseSorting.Name => exerciseQuery.OrderBy(x => x.Name),
                _ => exerciseQuery.OrderByDescending(x => x.Id)
            };

            var exercisesList = exerciseQuery
                .Select(x => new ExerciseListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                })
                .ToList();

            return new AllExercisesQueryModel
            {
                Exercises = exercisesList,
                SearchCriteria = searchCriteria,
                Sorting = sorting
            };
        }

        public IEnumerable<ExerciseListViewModel> Exercises()
        {
            var exercises = this.repo.All<Exercise>()
                .Select(x => new ExerciseListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                })
                .ToList();

            return exercises;
        }
    }
}