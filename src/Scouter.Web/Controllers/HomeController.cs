using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.Web.Controllers.Bases;
using Scouter.Web.Interfaces;
using Scouter.Web.Models;

namespace Scouter.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUser user, IUsuarioService usuarioService) : base(user, usuarioService)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Minor()
        {
            return View();
        }
    }
}
