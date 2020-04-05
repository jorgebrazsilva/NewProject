using Scouter.ApplicationCore.Interfaces.UoW;
using Scouter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scouter.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScouterContext _scouterContext;

        public UnitOfWork(ScouterContext scouterContext)
        {
            _scouterContext = scouterContext;
        }

        public bool Commit()
        {
            var rowsAffected = _scouterContext.SaveChanges();
            return rowsAffected > 0;
        }

        public async Task<bool> CommitAsync()
        {
            var rowsAffected = await _scouterContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public void Dispose()
        {
            _scouterContext.Dispose();
        }
    }
}
