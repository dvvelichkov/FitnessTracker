using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Extensions;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.Supplements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FitnessTracker.Controllers
{

    public class SupplementsController : Controller
    {

        private readonly IRepository repo;

        public SupplementsController(IRepository _repo)
        {
            this.repo = _repo;
        }

        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        public IActionResult All(string searchCriteria, SupplementSorting sorting)
        {
            var supplementQuery = this.repo.All<Supplement>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchCriteria))
            {
                supplementQuery = supplementQuery
                    .Where(x => x.Name.ToLower().Contains(searchCriteria.ToLower()));
            }

            supplementQuery = sorting switch
            {
                SupplementSorting.DateCreated => supplementQuery.OrderByDescending(x => x.Id),
                SupplementSorting.Name => supplementQuery.OrderBy(x => x.Name),
                SupplementSorting.NameDescending => supplementQuery.OrderByDescending(x=> x.Name),
                _ => supplementQuery.OrderByDescending(x => x.Id)
            };

            var supplements = supplementQuery
                .Select(x => new SupplementListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl,
                })
                .ToList();

            return View(new AllSupplementsQueryModel
            {
                Supplements = supplements,
                SearchCriteria = searchCriteria,
                Sorting = sorting
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddSupplementViewModel supplement)
        {
            var existingSupplement = this.repo.All<Supplement>()
                .Where(x => x.UserId == this.User.GetId())
                .ToList();

            if (existingSupplement.Any(x=> x.Name.ToLower() == supplement.Name.ToLower()))
            {
                this.ModelState.AddModelError(nameof(supplement.Name), "This supplement already exists!");
            }

            if (!ModelState.IsValid)
            {
                return View(supplement);
            }

            Supplement supplementData = new Supplement
            {
                Name = supplement.Name,
                Description = supplement.Description,
                ImageUrl = supplement.ImageUrl,
                Quantity = supplement.Quantity,
                UserId = this.User.GetId()
            };

            repo.Add(supplementData);
            repo.SaveChanges();

            return RedirectToAction(nameof(All));
        }
    }
}
