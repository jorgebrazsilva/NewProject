using Scouter.ApplicationCore.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scouter.ApplicationCore.Interfaces.Services.Bases
{
    public interface IBaseService<T> : IDisposable where T : BaseViewModel
    {
        T Add(T obj);
        T GetById(long id);
        T GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAllActive();
        T Update(T obj);
        bool Remove(long id);
        bool Remove(int id);
    }
}
