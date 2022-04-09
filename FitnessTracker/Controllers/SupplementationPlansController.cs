using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.SupplementationPlans;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class SupplementationPlansController : Controller
    {
        private readonly IRepository repo;
        public SupplementationPlansController(IRepository _repo)
        {
            this.repo = _repo;
        }

        public IActionResult Create()
        {
            return View(new CreateSupplementationPlanViewModel
            {
                Supplements = this.GetSupplementNames().ToList()
            });
        }

        [HttpPost]

        public IActionResult Create (CreateSupplementationPlanViewModel supplPlan)
        {
            var supplPlansCount = this.repo.All<SupplementationPlan>().ToList().Count();

            if(supplPlansCount >= 1)
            {
                this.ModelState.AddModelError(nameof(supplPlan.Name), "There is already an existing supplementation plan. Please edit it instead.");
            }

            if (!ModelState.IsValid)
            {
                supplPlan.Supplements = this.GetSupplementNames().ToList();
                return View(supplPlan);
            }

            var supplPlanData = new SupplementationPlan
            {
                Name = supplPlan.Name
            };

            foreach (var option in supplPlan.Supplements)
            {
                if (option.IsChecked == true)
                {
                    var supplements = repo.All<Supplement>().ToList();
                    var supplementToAdd = supplements.Where(x => x.Id == option.Id).FirstOrDefault();

                    supplPlanData.Supplements.Add(supplementToAdd);
                }
            }
            repo.Add(supplPlanData);
            repo.SaveChanges();

            return RedirectToAction("Index, Home");
        }

        private IEnumerable<SupplPlanSupplementViewModel> GetSupplementNames()
        {
            return this.repo.All<Supplement>()
                 .Select(x => new SupplPlanSupplementViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     ImageUrl = x.ImageUrl,
                     Description = x.Description,
                     Quantity = x.Quantity
                 })
                 .ToList();
        }
    }
}
