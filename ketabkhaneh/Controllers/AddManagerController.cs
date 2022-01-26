using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ketabkhaneh.Models;
using ketabkhaneh.Models.DB;
using ketabkhaneh.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ketabkhaneh.Controllers
{
    public class AddManagerController : Controller
    {
        private readonly EduDBContext _db;
        public AddManagerController(EduDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]

        public IActionResult SignUp(AddManagerViewModel svm)
        {
            if (ModelState.IsValid)
            {

                var manager = new Manager
                {

                    Name = svm.Name,
                    LastName = svm.LastName,
                    Email = svm.Email.ToString(),
                    Phone = svm.Phone,
                    tarikhtavalod = svm.tarikhtavalod,
                    Role = Person.Roles.Admin,
                    Password = svm.Password
                };
                _db.Managers.Add(manager);
                _db.SaveChanges();
                return Redirect("/");
            }

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var admin = _db.Managers.FirstOrDefault(a => a.Email == loginViewModel.Email &&
            a.Password == loginViewModel.PassWord);
            if (admin == null)
            {
                ModelState.AddModelError("Eamil", "اطلاعات ورودی اشتباه است");
                return View(loginViewModel);
            }
            List<Claim> Claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role , admin.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier , loginViewModel.Email),
                new Claim(ClaimTypes.Name , admin.Name)
            };
            var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var Claimprincipal = new ClaimsPrincipal(Identity);
            var prop = new AuthenticationProperties()
            {
                IsPersistent = false
            };
            HttpContext.SignInAsync(Claimprincipal, prop);
            return Redirect("/PanelManager");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}
