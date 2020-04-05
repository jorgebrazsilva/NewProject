using Microsoft.EntityFrameworkCore;
using Scouter.ApplicationCore.Entities.Bases;
using Scouter.ApplicationCore.Interfaces.Repository.Bases;
using Scouter.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Scouter.Infrastructure.Repository.Bases
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity<TEntity>
    {
        protected readonly ScouterContext Db;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(ScouterContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            obj.Ativar();
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(long id)
        {
            DbSet.Remove(GetById(id));
        }

        public virtual void Inactivate(long id)
        {
            var entity = GetById(id);
            entity.Inativar();
            Update(entity);
        }

        public virtual void Inactivate(int id)
        {
            var entity = GetById(id);
            entity.Inativar();
            Update(entity);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(GetById(id));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual IEnumerable<TEntity> GetAllActive()
        {
            return DbSet.AsNoTracking().Where(x => x.Ativo);
        }

        public virtual TEntity GetById(long id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}
