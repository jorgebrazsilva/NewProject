using AutoMapper;
using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.Interfaces.Repository;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.Interfaces.UoW;
using Scouter.ApplicationCore.Services.Bases;
using Scouter.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.Services
{
    public class UsuarioService : BaseService<UsuarioViewModel, Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper, usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;         
        }

        public UsuarioViewModel GetById(Guid id)
        {
            var usuario = _mapper.Map<UsuarioViewModel>(_usuarioRepository.GetById(id));         
            return usuario;
        }
        
        public bool IsActive(string email)
        {
            return _usuarioRepository.IsActive(email);
        }

        public bool Remove(Guid id)
        {
            _usuarioRepository.Inactivate(id);
            return Commit();
        }
    }
}
