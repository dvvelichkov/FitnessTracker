using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.Supplements;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]

        public IActionResult Add(AddSupplementViewModel supplement)
        {
            var existingSupplement = this.repo.All<Supplement>().ToList();

            if (existingSupplement.Any(x => x.Name.ToLower() == supplement.Name.ToLower()))
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
                Quantity = supplement.Quantity
            };

            repo.Add(supplementData);
            repo.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
