using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ketabkhaneh.Models.DB
{
    public class User: Person
    {
		public virtual ICollection<Loan> Loans { get; set; }
	}
}
