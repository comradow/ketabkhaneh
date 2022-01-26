using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "رمز")]
        [Required(ErrorMessage ="{0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
