using AutoMapper;
using Scouter.ApplicationCore.Entities.Bases;
using Scouter.ApplicationCore.Interfaces.Repository.Bases;
using Scouter.ApplicationCore.Interfaces.Services.Bases;
using Scouter.ApplicationCore.Interfaces.UoW;
using Scouter.ApplicationCore.ViewModels.Bases;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scouter.ApplicationCore.Services.Bases
{
    public abstract class BaseService<T, TEntity> : IBaseService<T> where T : BaseViewModel where TEntity : BaseEntity<TEntity>
    {
        private readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;
        protected readonly IBaseRepository<TEntity> _repository;

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper, IBaseRepository<TEntity> repository)
        {
            _uow = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        protected bool Commit()
        {
            return _uow.Commit();
        }

        protected async Task<bool> CommitAsync()
        {
            return await _uow.CommitAsync();
        }
        public virtual T Add(T obj)
        {           
            var entity = _mapper.Map<TEntity>(obj);
           

            _repository.Add(entity);

            Commit();
             

            return _mapper.Map<T>(entity);
        }

        public virtual T GetById(long id)
        {
            return _mapper.Map<T>(_repository.GetById(id));
        }
        public virtual T GetById(int id)
        {
            return _mapper.Map<T>(_repository.GetById(id));
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<T>>(await _repository.GetAllAsync());
        }

        public virtual IEnumerable<T> GetAllActive()
        {
            return _mapper.Map<IEnumerable<T>>(_repository.GetAllActive());
        }

        public virtual T Update(T obj)
        {           
            var entity = _mapper.Map<TEntity>(obj);
           

            _repository.Update(entity);

            Commit();
             

            return _mapper.Map<T>(entity);
        }

       

        public virtual bool Remove(long id)
        {
            _repository.Inactivate(id);
            return Commit();
        }
        public virtual bool Remove(int id)
        {
            _repository.Inactivate(id);
            return Commit();
        }
        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
