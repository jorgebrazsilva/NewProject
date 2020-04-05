using AutoMapper;
using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.Interfaces.Repository;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.Interfaces.UoW;
using Scouter.ApplicationCore.Services.Bases;
using Scouter.ApplicationCore.ViewModels;

namespace Scouter.ApplicationCore.Services
{
    public class LevelService : BaseService<LevelViewModel, Level>, ILevelService
    {
        private readonly ILevelRepository _levelRepository;

        public LevelService(ILevelRepository levelRepository, IUnitOfWork uow, IMapper mapper) : base(uow, mapper, levelRepository)
        {
            _levelRepository = levelRepository;
        }

        public override void Dispose()
        {
            _levelRepository.Dispose();
        }
    }
}