using FitnessTracker.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;
using FitnessTracker.Infrastructure.Models;
using System.Linq;
using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Extensions;

namespace FitnessTracker.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IRepository repo;
        public UsersController(UserManager<User> _userManager, SignInManager<User> _signInManager, IRepository _repo)
        {
                this.userManager = _userManager;
                this.signInManager = _signInManager;
                this.repo = _repo;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

            var userMailExists = this.repo.All<User>().Any(x=> x.Email == user.Email);

            if(userMailExists)
            {
                this.ModelState.AddModelError(nameof(user.Password),
                    "This e-mail is already used. Please enter another e-mail address.");
            }
            if(!userMailExists)
            {
                var registeredUser = new User
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    UserName = user.Email
                };

                var result = await this.userManager.CreateAsync(registeredUser, user.Password);

                if (!result.Succeeded)
                {
                    var errors = result.Errors.Select(x => x.Description);

                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return View(user);
                }
            }

            return RedirectToAction("Index, Home");
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login()
        {

        }
    }
}
