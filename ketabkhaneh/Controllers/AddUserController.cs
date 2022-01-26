using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ketabkhaneh.Models;
using ketabkhaneh.Models.DB;
using ketabkhaneh.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ketabkhaneh.Controllers
{
	public class AddUserController : Controller
	{
		private readonly EduDBContext _db;
		public AddUserController(EduDBContext db)
		{
			_db = db;
		}

		/// <summary>
		/// insert
		/// </summary>
		/// <returns></returns>
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
				var User = new User
				{
					Name = svm.Name,
					LastName = svm.LastName,
					Email = svm.Email.ToString(),
					Phone = svm.Phone,
					Role = Person.Roles.User,
					Password = svm.Password,
					tarikhtavalod = svm.tarikhtavalod
				};
				_db.Users.Add(User);
				_db.SaveChanges();
				return Redirect("/");
			}
			return View(svm);
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel loginViewModel)
		{
			var user = _db.Users.FirstOrDefault(a => a.Email == loginViewModel.Email &&
		   a.Password == loginViewModel.PassWord);
			if (user == null)
			{
				ModelState.AddModelError("Eamil", "اطلاعات ورودی اشتباه است");
				return View(loginViewModel);
			}
			List<Claim> Claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Role , user.Role.ToString()),
				new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
				new Claim(ClaimTypes.Name , user.Name)
			};
			var Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
			var Claimprincipal = new ClaimsPrincipal(Identity);
			var prop = new AuthenticationProperties()
			{
				IsPersistent = false
			};
			HttpContext.SignInAsync(Claimprincipal, prop);
			return Redirect("/PanelUser");
		}

	}
}


