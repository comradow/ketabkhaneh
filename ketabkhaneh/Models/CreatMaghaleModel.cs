using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ketabkhaneh.Models
{
    public class CreatMaghaleModel
    {
        
        [Required]

        public string Title { get; set; }

        [Required]
        public string Mozo { get; set; }

        [Required]
        public string Shabak { get; set; }

        [Required]
        public string CountPage { get; set; }

        [Required]
        public string YearNashr { get; set; }


        public string mozo2 { get; set; }

        [Required]
        public string Nasher { get; set; }

        [Required]
        public string Upload { get; set; }

    }
}
