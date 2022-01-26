using ketabkhaneh.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Controllers
{
	public class HomeController : Controller
	{
		private readonly EduDBContext _context;

		public HomeController(EduDBContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		//[HttpPost]
		public IActionResult Search(string parametr)
		{
			var res=_context.BooksAndMags.Where(p => p.Name.Contains(parametr) ||
			p.Category.Contains(parametr) ||
			p.Author.Contains(parametr));
			return View(res.ToList());
		}
	}
}
