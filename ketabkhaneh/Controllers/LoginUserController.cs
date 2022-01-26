using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ketabkhaneh.Controllers
{
    public class LoginUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
