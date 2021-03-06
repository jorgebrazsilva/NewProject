using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using Scouter.Web.Controllers.Bases;
using Scouter.ApplicationCore.Enumerators;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.ViewModels;
using Scouter.Web.Interfaces;
using Scouter.ApplicationCore.Exception;

namespace Scouter.Web.Controllers
{
    //[Authorize()]
    public class PositionController : BaseController
    {
        private readonly IPositionService _positionService;
        public PositionController(IUser user, IUsuarioService usuarioService, UserManager<IdentityUser> userManager, IPositionService positionService) : base(user, usuarioService)
        {
            _positionService = positionService;
        }

        public IActionResult Index()
        {
            var model = new List<PositionViewModel>();
            try
            {
                model.AddRange(_positionService.GetAllActive().ToList());
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UsuarioId = UserId;
                    _positionService.Add(model);
                    AlertToastr(EnumTipoAlert.success, "Registro cadastrado com sucesso.");
                    return RedirectToAction("Index");
                }
            }
            catch (RegraNegocioException ex)
            {
                AlertToastr(EnumTipoAlert.warning, ex.Message);
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new PositionViewModel();
            try
            {
                model = _positionService.GetById(id);
            }
            catch (RegraNegocioException ex)
            {
                AlertToastr(EnumTipoAlert.warning, ex.Message);
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(PositionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _positionService.Update(model);
                    AlertToastr(EnumTipoAlert.success, "Registro atualizado com sucesso.");
                    return RedirectToAction("Index");
                }
            }
            catch (RegraNegocioException ex)
            {
                AlertToastr(EnumTipoAlert.warning, ex.Message);
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
            }
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return NotFound("Registro não encontrado.");

                var success = _positionService.Remove(id);
                if (!success) return BadRequest("Não foi possível remover o registro.");

                return Ok("Registro removido com sucesso.");
            }
            catch (RegraNegocioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
