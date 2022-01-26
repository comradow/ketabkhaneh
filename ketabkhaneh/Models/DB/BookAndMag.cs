using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Models.DB
{
	public class BookAndMag : BaseModel
	{
		[Display(Name = "نام")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Name { get; set; }
		[Display(Name = "نویسنده")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Author { get; set; }
		[Display(Name = "دسته بندی")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public string Category { get; set; }
		[Display(Name = "نوع")]
		[Required(ErrorMessage = "{0} را وارد کنید")]
		public Types Type { get; set; }

		public virtual ICollection<Loan> Loans { get; set; }
		public enum Types
		{
			Book,
			Magazine
		}
	}
}
