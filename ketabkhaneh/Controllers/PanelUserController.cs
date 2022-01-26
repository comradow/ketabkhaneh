using ketabkhaneh.Models.DB;
using ketabkhaneh.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace ketabkhaneh.Controllers
{
	[Authorize]
	public class PanelUserController : Controller
	{
		private readonly EduDBContext _db;
		public PanelUserController(EduDBContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var loanList = new List<BorrowedAndUserViewModel>();
			var books = _db.Loans.Include(l => l.BookAndMag).Include(u => u.User).Where(u => u.UserId.ToString() == UserUtil.GetUserID(User)).ToList();

			foreach (var item in books)
			{
				loanList.Add(new BorrowedAndUserViewModel()
				{
					UserName = item.BookAndMag.Name,
					BookOrMagName = item.BookAndMag.Name,
					BorrowedDate = item.BorrowedDate,
					ReturnDate = item.ReturnDate,
					IsReturned = item.IsReturned,
					BookOrMagId = item.BookAndMagId
				});
			}
			return View(loanList);
		}
		public IActionResult Borrow()
		{
			return View(_db.BooksAndMags.ToList());
		}

		[HttpPost]
		public IActionResult Borrow(string bookid)
		{
			_db.Loans.Add(new Loan()
			{
				BookAndMagId = Guid.Parse(bookid),
				ReturnDate = DateTime.Now.AddMonths(1),
				BorrowedDate = DateTime.Now,
				UserId = Guid.Parse(UserUtil.GetUserID(User)),
				IsReturned = false
			});
			_db.SaveChanges();
			return Redirect("/PanelUser");
		}

		[HttpPost]
		public IActionResult Return(string bookid)
		{
			var BM = _db.Loans.FirstOrDefault(b => b.BookAndMagId == Guid.Parse(bookid));
			BM.IsReturned = true;
			_db.SaveChanges();
			return Redirect("/PanelUser");
		}
	}
}
