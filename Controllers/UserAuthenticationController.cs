using AminesStream.Models.Auth;
using AminesStream.Repositories.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AminesStream.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;

        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }

        public async Task<IActionResult> Register()
        {
            // Only first Auth is going to be a an admin, others will be invited as admin or simple users
            var model = new RegistrationModel
            {
               
                  Email = "adminmain@mail.com",
                  Username = "AdminOne",
                  Name = "Veron",
                  Password = "Veroni3434!",
                  PasswordConfirm = "Veroni3434!",
                  Role = "Admin"
            };
             var result = await authService.RegisterAsync(model);
            return Ok(result);
        }

        public async Task<IActionResult> Login() {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if(result.StatusCode == 1)
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                TempData["msg"] = "Error on Authentication";
                return RedirectToAction(nameof(Login));
            }
        }

        public async Task<IActionResult> Logout()
        {

           await authService.LogoutAsync();
                return RedirectToAction(nameof(Login));
        }
    }
}
