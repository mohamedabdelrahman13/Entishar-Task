using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Users_CRUD.Interfaces;
using Users_CRUD.ViewModels;

namespace Users_CRUD.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService AccountService)
        {
            this.accountService = AccountService;
        }
        public IActionResult LoginView()
        {
            return View("Login");  
        }

        public async Task<IActionResult> SaveSignIn(LoginVM loginVm)
        {
            if (ModelState.IsValid) 
            {
                var signInResult = accountService.SignInCheck(loginVm);

                if (signInResult.isSuccessful == false)
                {
                    ViewBag.Message = signInResult.message;
                    return RedirectToAction("LoginView", loginVm);
                }


                //creating the claims of the cookie ..
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginVm.Username),
                };

                //create the identity ..
                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);


                //sign in 
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
               new ClaimsPrincipal(identity));
                return RedirectToAction("Index", "Home");

            }
            return RedirectToAction("LoginView", loginVm);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginView");
        }

    }
}
