using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Extensions;
using FitnessTracker.Infrastructure.Models;
using FitnessTracker.Models.Infrastructure;
using FitnessTracker.Models.SupplementationPlans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult Create(CreateSupplementationPlanViewModel supplPlan)
        {
            if (!ModelState.IsValid)
            {
                supplPlan.Supplements = this.GetSupplementNames().ToList();
                return View(supplPlan);
            }

            var userId = this.User.GetId();
            var userSupplPlanCount = this.repo.All<SupplementationPlan>().Where(x => x.UserId == userId).ToList();

            if (userSupplPlanCount.Count() > 0)
            {
                this.ModelState.AddModelError(nameof(supplPlan.Name),
                    "You already have an existing supplementation plan. Please edit it instead.");
                supplPlan.Supplements = this.GetSupplementNames().ToList();
                return View(supplPlan);
            }

            if (userSupplPlanCount.Count() == 0)
            {
                var supplPlanData = new SupplementationPlan
                {
                    Name = supplPlan.Name,
                    UserId = userId
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
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult All()
        {

            var supplementationPlans = this.repo.All<SupplementationPlan>()
                .OrderByDescending(x => x.Id)
                .Select(x => new SupplPlanListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Supplements = x.Supplements.Select(x => new SupplPlanSupplementViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Quantity = x.Quantity
                    })
                })
                .ToList();

            return View(supplementationPlans);
        }

        [Authorize]
        public IActionResult Edit(string name)
        {
            var supplPlan = this.Details(name);

            if (supplPlan.UserId != this.User.GetId())
            {
                return BadRequest();
            }

            return View(new CreateSupplementationPlanViewModel
            {
                Name = supplPlan.Name,
                UserId = supplPlan.UserId,
                Supplements = this.GetSupplementNames().ToList()
            });
        }

        [HttpPost]
        [Authorize]

        public IActionResult Edit(CreateSupplementationPlanViewModel supplPlan)
        {
            if (!ModelState.IsValid)
            {
                supplPlan.Supplements = this.GetSupplementNames().ToList();
                return View(supplPlan);
            }

            var supplPlanData = this.repo.All<SupplementationPlan>()
                .Where(x => x.UserId == this.User.GetId())
                .First();

            if (supplPlanData.UserId != this.User.GetId())
            {
                return BadRequest();
            }
            supplPlanData.Name = supplPlan.Name;
            supplPlan.Supplements = this.GetSupplementNames().ToList();
            supplPlanData.Supplements.Clear();

            foreach (var supplement in supplPlan.Supplements)
            {
                if (supplement.IsChecked == true)
                {
                    var supplements = repo.All<Supplement>().ToList();
                    var supplementToAdd = supplements.Where(x => x.Id == supplement.Id).FirstOrDefault();

                    if (supplPlanData.Supplements.Contains(supplementToAdd))
                    {
                        this.ModelState.AddModelError(nameof(supplementToAdd),
                    "You already have such existing supplementation in your plan.");
                        return View(supplPlan);
                    }

                    supplPlanData.Supplements.Add(supplementToAdd);
                }
            }

            repo.SaveChanges();

            return RedirectToAction("Mine", "SupplementationPlans");
        }
        public IActionResult Mine()
        {
            var supplementationPlans = this.repo.All<SupplementationPlan>()
                .Where(x => x.UserId == this.User.GetId())
                .OrderByDescending(x => x.Id)
                .Select(x => new SupplPlanListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Supplements = x.Supplements.Select(x => new SupplPlanSupplementViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Quantity = x.Quantity
                    })
                })
                .ToList();

            return View(supplementationPlans);
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

        public CreateSupplementationPlanViewModel Details(string name)
        {
            return this.repo.All<SupplementationPlan>()
                .Where(x => x.Name == name)
                .Select(x => new CreateSupplementationPlanViewModel
                {
                    Name = x.Name,
                    UserId = x.UserId
                })
                .FirstOrDefault();
        }

    }
}
