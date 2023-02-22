using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = model.EmailAddress,
                    UserName = model.UserName,
                    Name = model.FullName,
                    PhoneNumber = model.MobileNumber,
                    Gender = model.Gender,
                    IdProof = model.IdProof,
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (model.UserName.Equals("Admin@Rahul"))
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("AdminDashboard","Dashboard");
                    }
                    else
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("UserDashboard","Dashboard");
                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLogInModel model)
        {
            if (model.Username == null) return View(model);
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                  return RedirectToAction("UserDashboard", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Error username or password");
                return View(model);
            }
        }
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AdminLogin(AdminLogInModel model)
        {
            if (model.Username == null) return View(model);
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                 return RedirectToAction("AdminDashboard", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Error username or password");
                return View(model);
            }
        }
    }
}
