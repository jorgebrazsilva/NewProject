using Microsoft.EntityFrameworkCore;
using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.Interfaces.Repository;
using Scouter.Infrastructure.Context;
using Scouter.Infrastructure.Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scouter.Infrastructure.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ScouterContext db) : base(db)
        {
        }

        public Usuario GetById(Guid id)
        {
            return DbSet.Where(u => u.UsuarioId == id).AsNoTracking().SingleOrDefault();
        }       
        public bool IsActive(string email)
        {
            return DbSet
                .Where(x => x.Email.Equals(email) && x.Ativo)
                .AsNoTracking()
                .SingleOrDefault() != null;
        }

        public void Inactivate(Guid id)
        {
            var entity = GetById(id);
            entity.Inativar();
            Update(entity);
        }
    }
}
