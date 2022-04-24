using FitnessTracker.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static FitnessTracker.Infrastructure.Constants.DataConstants;
using FitnessTracker.Infrastructure.Models;
using System.Linq;
using FitnessTracker.Infrastructure.Common;
using FitnessTracker.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace FitnessTracker.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var userMailExists = this.repo.All<User>().Any(x => x.Email == user.Email);

            if (userMailExists)
            {
                this.ModelState.AddModelError(nameof(user.Email),
                    "This e-mail is already used! Please enter another e-mail address.");
                return View(user);
            }

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


            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            var userToBeLoggedIn = await this.userManager.FindByEmailAsync(user.Email);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials!");
                return View(user);
            }
            var passwordIsValid = await this.userManager.CheckPasswordAsync(userToBeLoggedIn, user.Password);

            if (!passwordIsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials!");
                return View(user);
            }

            await this.signInManager.SignInAsync(userToBeLoggedIn, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            if (HttpContext.Request.Cookies.Count > 0)
            {
                var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.")
                || c.Key.Contains("Microsoft.Authentication"));
                foreach (var cookie in siteCookies)
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }

            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            
            return RedirectToAction("Index", "Home");
        }
    }
}
