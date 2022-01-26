using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Models.DB
{
    public class Person: BaseModel
    {

        [Required]

        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public string tarikhtavalod { get; set; }
        public Roles Role { get; set; }
        public DateTimeOffset SigninDate { get; set; } = DateTime.Now;

		public enum Roles
        {
            Admin,
            User
        }
    }
}
