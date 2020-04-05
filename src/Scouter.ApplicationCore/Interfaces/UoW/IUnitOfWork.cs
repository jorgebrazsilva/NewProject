using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scouter.ApplicationCore.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}
