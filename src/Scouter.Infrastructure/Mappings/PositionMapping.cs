using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scouter.ApplicationCore.Entities;
using Scouter.Infrastructure.Extensions;

namespace Scouter.Infrastructure.Mappings
{
    public class PositionMapping : EntityTypeConfiguration<Position>
    {
        public override void Map(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
