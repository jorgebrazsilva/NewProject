using Scouter.ApplicationCore.Entities.Bases;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scouter.ApplicationCore.Interfaces.Repository.Bases
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(long id);
        TEntity GetById(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> GetAllActive();
        void Update(TEntity obj);
        void Remove(long id);
        void Remove(int id);
        void Inactivate(long id);
        void Inactivate(int id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
