using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LibOnline.Controllers.Authorization
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}