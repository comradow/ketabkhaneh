using ketabkhaneh.Models.DB;
using ketabkhaneh.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Controllers
{
	[Authorize(Roles = "Admin")]
	public class PanelManagerController : Controller
	{
		private readonly EduDBContext _db;
		public PanelManagerController(EduDBContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			return View(_db.Users.ToList());
		}

		public IActionResult BorrowedBooks()
		{
			var loanList = new List<BorrowedAndUserViewModel>();
			var books = _db.Loans.Include(l => l.BookAndMag).Include(u => u.User).AsQueryable();

			foreach (var item in books)
			{
				loanList.Add(new BorrowedAndUserViewModel()
				{
					UserName = item.BookAndMag.Name,
					BookOrMagName = item.BookAndMag.Name,
					BorrowedDate = item.BorrowedDate,
					ReturnDate = item.ReturnDate,
					IsReturned = item.IsReturned
				});
			}
			var res = _db.BooksAndMags.ToList();
			return View(loanList);
		}
	}
}
