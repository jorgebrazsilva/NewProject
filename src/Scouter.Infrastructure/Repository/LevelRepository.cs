using Scouter.ApplicationCore.Entities;
using Scouter.ApplicationCore.Interfaces.Repository;
using Scouter.Infrastructure.Context;
using Scouter.Infrastructure.Repository.Bases;

namespace Scouter.Infrastructure.Repository
{
    public class LevelRepository : BaseRepository<Level>, ILevelRepository
    {
        public LevelRepository(ScouterContext db) : base(db)
        {
        }
    }
}
