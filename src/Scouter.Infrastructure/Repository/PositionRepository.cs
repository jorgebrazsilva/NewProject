using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.Interfaces.Repository;
using Scouter.Infrastructure.Context;
using Scouter.Infrastructure.Repository.Bases;

namespace Scouter.Infrastructure.Repository
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {
        public PositionRepository(ScouterContext db) : base(db)
        {
        }
    }
}
