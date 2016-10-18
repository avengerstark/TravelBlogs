using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Security.Claims;
using TravelBlogs.BLL.Interfaces;
using TravelBlogs.BLL.DTO;
using TravelBlogs.WEB.Models;
using TravelBlogs.BLL.Infrastructure;
using Microsoft.AspNet.Identity;

namespace TravelBlogs.WEB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly ITravelBlogsService _travelService;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(ITravelBlogsService tbs)
        {
            _travelService = tbs;
        }



        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {                
                ClaimsIdentity claim = await _travelService.Users.Authenticate(viewModel.Email, viewModel.Password);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index","Home");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    UserName = model.Email,
                    Role = "user"
                };
                ValidationException validationDetails = await _travelService.Users.Create(userDto);
                if (validationDetails.Succeed)
                {
                    _travelService.SaveChanges();
                    ClaimsIdentity claim = await _travelService.Users.Authenticate(model.Email, model.Password);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError(validationDetails.Property, validationDetails.Message);
            }
            return View(model);
        }


        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _travelService.Users.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeed)
            {
                ClaimsIdentity claim = await _travelService.Users.Authenticate(User.Identity.Name, model.NewPassword);

                if (claim != null)
                {
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                }
                TempData["message"] = result.Message;
                return RedirectToAction("Manage");
            }
            ModelState.AddModelError(result.Property, result.Message);
            TempData["message"] = result.Message;
            return View(model);
        }



        public ActionResult Manage()
        {
            return View();
        }

        private async Task SetInitialDataAsync()
        {
            await _travelService.Users.SetInitialData(new UserDTO
            {
                Email = "avengerstark99@gmail.com",
                UserName = "avengerstark99@gmail.com",
                Password = "ad46D_ewr3",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }

        protected override void Dispose(bool disposing)
        {
            _travelService.Dispose();
            base.Dispose(disposing);
        }
    
    }
}