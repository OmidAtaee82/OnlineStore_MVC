using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Store.ViewModel.Auth;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Online_Store.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Route("/account/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [Route("/account/register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email , 
                Email = model.Email , 
                FullName = model.FullName , 
            };


            var result = await _userManager.CreateAsync(user , model.Password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user , "Customer");

                if (!roleResult.Succeeded)
                {
                    foreach(var error in roleResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);

                return Redirect("/");
            }


            foreach (var error in result.Errors)
            {
                var message = error.Code switch
                {
                    "PasswordTooShort" => "رمز عبور باید حداقل 6 کاراکتر باشد ." ,
                    "DuplicateUserName" => "این نام کاربری قبلا ثبت شده است " ,
                    "DuplicateEmail" => "این ایمیل قبلا ثبت شده است " , 
                    _ => "خطایی در ثبت نام رخ داده است"
                };
                ModelState.AddModelError("", message);
            }

            return View(model);

        }

        [Route("/account/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [Route("/account/login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(LoginVM model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                model. Email, 
                model.Password , 
                model.RememberMe , 
                lockoutOnFailure:false
                );

            if (result.Succeeded)
            {
                return Redirect("/");
            }

            ModelState.AddModelError("" , "ایمیل یا پسورد شما نامعتبر است !");
            return View(model);

        }


        [Route("/account/logout")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
