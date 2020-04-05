using Scouter.ApplicationCore.Interfaces.Services.Bases;
using Scouter.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<UsuarioViewModel>
    {
      
        UsuarioViewModel GetById(Guid id);
        bool Remove(Guid id);
        bool IsActive(string email);
    }
}
