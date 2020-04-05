using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.ViewModels;
using Scouter.Web.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using Scouter.Web.Controllers.Bases;
using Scouter.ApplicationCore.Enumerators;

namespace Scouter.Web.Controllers
{
    //[Authorize()]
    public class LevelController : BaseController
    {
        private readonly ILevelService _levelService;
        public LevelController(IUser user, IUsuarioService usuarioService, UserManager<IdentityUser> userManager, ILevelService levelService) : base(user, usuarioService)
        {
            _levelService = levelService;
        }

        public IActionResult Index()
        {
            var model = new List<LevelViewModel>();
            try
            {
                model.AddRange(_levelService.GetAllActive().ToList());
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
                AdicionarExceptionToModelState(ex);
            }
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LevelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UsuarioId = UserId;
                    _levelService.Add(model);
                    AlertToastr(EnumTipoAlert.success, "Registro cadastrado com sucesso.");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
                AdicionarExceptionToModelState(ex);
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var model = new LevelViewModel();
            try
            {
                model = _levelService.GetById(id);
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
                AdicionarExceptionToModelState(ex);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(LevelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _levelService.Update(model);
                    AlertToastr(EnumTipoAlert.success, "Registro atualizado com sucesso.");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                AlertToastr(EnumTipoAlert.error, ex.Message);
                AdicionarExceptionToModelState(ex);
            }
            return View(model);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return NotFound("Registro não encontrado.");

                var success = _levelService.Remove(id);
                if (!success) return BadRequest("Não foi possível remover o registro.");

                return Ok("Registro removido com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
