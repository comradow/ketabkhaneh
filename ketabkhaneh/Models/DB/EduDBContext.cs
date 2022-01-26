using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ketabkhaneh.Models.DB;


namespace ketabkhaneh.Models.DB
{
    public class EduDBContext : DbContext
    {

        public EduDBContext(DbContextOptions<EduDBContext> options) : base(options)
        {

            //Database.EnsureCreated();
        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<BookAndMag> BooksAndMags { get; set; }
		public bool IsReturned { get; set; }

	}
}
