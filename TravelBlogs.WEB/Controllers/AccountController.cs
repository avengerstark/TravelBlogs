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

namespace TravelBlogs.WEB.Controllers
{
    public class AccountController : Controller
    {

        private ITravelBlogsService travelService;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController(ITravelBlogsService tbs)
        {
            travelService = tbs;
        }



        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password};
                ClaimsIdentity claim = await travelService.Users.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }


        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Role = "user"
                };
                ValidationException validationDetails = await travelService.Users.Create(userDto);
                if (validationDetails.Succeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(validationDetails.Property, validationDetails.Message);
            }
            return View(model);
        }
        private async Task SetInitialDataAsync()
        {
            await travelService.Users.SetInitialData(new UserDTO
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "ad46D_ewr3",
                Name = "Семен Семенович Горбунков",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }

        protected override void Dispose(bool disposing)
        {
            travelService.Dispose();
            base.Dispose(disposing);
        }
    
    }
}