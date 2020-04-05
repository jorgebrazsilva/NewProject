using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scouter.ApplicationCore.Entities;
using Scouter.Infrastructure.Extensions;

namespace Scouter.Infrastructure.Mappings
{
    public class LevelMapping : EntityTypeConfiguration<Level>
    {
        public override void Map(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id);

            builder.Property(p => p.LevelName)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.LevelNameNote)
                .HasColumnType("varchar(8000)");

        }

    }
}

