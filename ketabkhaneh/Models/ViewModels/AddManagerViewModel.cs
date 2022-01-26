using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ketabkhaneh.Models.ViewModels
{
   
    public class AddManagerViewModel
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
    }
}
