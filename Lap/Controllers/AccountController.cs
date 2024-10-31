using Application.Abstract;
using Domain.Entities;
using Infrastructure.DataAccess;
using Lap.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lap.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly BookContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            BookContext context, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {
            if (!ModelState.IsValid) return View();

            var appUser = vm.UserName.Contains("@")
             ? await _userManager.FindByEmailAsync(vm.UserName)
             : await _userManager.FindByNameAsync(vm.UserName);

            var result = await _signInManager.PasswordSignInAsync(appUser, vm.Password, vm.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(appUser, "Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Login", "Failed to login");
                return View(vm);
            }
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = new AppUser
            {
                UserName = vm.UserName,
                FullName = vm.FullName,
                Email = vm.Email,
            };

            var result = await _userManager.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                return RedirectToAction("Login", "Account");
            }
            AddErrors(result);
            return View(vm);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
