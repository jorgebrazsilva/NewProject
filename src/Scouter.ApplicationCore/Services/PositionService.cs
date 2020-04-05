using AutoMapper;
using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.Interfaces.Repository;
using Scouter.ApplicationCore.Interfaces.Services;
using Scouter.ApplicationCore.Interfaces.UoW;
using Scouter.ApplicationCore.ViewModels;
using Scouter.ApplicationCore.Services.Bases;

namespace Scouter.ApplicationCore.Services
{
    public class PositionService : BaseService<PositionViewModel, Position>, IPositionService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository, IUnitOfWork uow, IMapper mapper) : base(uow, mapper, positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public override void Dispose()
        {
            _positionRepository.Dispose();
        }
    }
}