using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scouter.ApplicationCore.Enumerators;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.ViewModels;
using Scouter.ApplicationCore.ViewModels.Bases;
using Scouter.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scouter.Web.Controllers.Bases
{
    public class BaseController : Controller
    {
        private readonly IUser _user;
        protected readonly Guid UserId;

        protected readonly IUsuarioService _usuarioService;
        protected readonly UsuarioViewModel UsuarioLogadoViewModel;

        public BaseController(IUser user, IUsuarioService usuarioService)
        {
            _user = user;
            _usuarioService = usuarioService;

            if (_user.IsAuthenticated())
            {
                UserId = _user.GetUserId();
                UsuarioLogadoViewModel = _usuarioService.GetById(UserId);
            }

        }      
        protected void AdicionarExceptionToModelState(Exception ex)
        {
            if (ex != null)
            {
                ModelState.AddModelError("", ex.Message);
                AdicionarExceptionToModelState(ex.InnerException);
            }
        }
        protected void AdicionarIdentityExceptionToModelState(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        protected void AlertToastr(EnumTipoAlert tipo, string mensagem)
        {
            TempData["AlertToastr"] = $"toastr['{tipo.ToString()}']('{mensagem}')";
        }
    }
}
