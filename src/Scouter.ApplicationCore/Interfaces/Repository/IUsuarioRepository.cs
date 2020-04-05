using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.Interfaces.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.ApplicationCore.Interfaces.Repository
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetById(Guid id);
        void Inactivate(Guid id);     
        bool IsActive(string email);
    }
}
