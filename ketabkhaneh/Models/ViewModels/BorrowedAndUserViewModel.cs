using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Models.ViewModels
{
	public class BorrowedAndUserViewModel
	{
		public Guid BookOrMagId { get; set; }
		public string BookOrMagName { get; set; }
		public string UserName { get; set; }
		public DateTimeOffset ReturnDate { get; set; }
		public DateTimeOffset BorrowedDate { get; set; }
		public bool IsReturned { get; set; }
	}
}
