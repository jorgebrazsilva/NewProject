using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Scouter.Web.Controllers
{
    public class FormsController : Controller
    {
        public IActionResult BasicFroms()
        {
            return View();
        }
        public IActionResult Advanced()
        {
            return View();
        }
    }
}