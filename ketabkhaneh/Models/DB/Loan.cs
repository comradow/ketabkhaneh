using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Models.DB
{
	public class Loan:BaseModel
	{
		public Guid UserId { get; set; }
		public Guid BookAndMagId { get; set; }
		public DateTimeOffset BorrowedDate { get; set; } = DateTime.Now;
		public DateTimeOffset ReturnDate { get; set; }
		public bool IsReturned { get; set; }


		[ForeignKey("UserId")]
		public virtual User User { get; set; }
		[ForeignKey("BookAndMagId")]
		public virtual BookAndMag BookAndMag { get; set; }
	}
}
