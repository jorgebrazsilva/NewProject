using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scouter.ApplicationCore.Entities;
using Scouter.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scouter.Infrastructure.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public override void Map(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.UsuarioId);

            builder.Property(p => p.UsuarioId);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Telefone)
                .HasColumnType("varchar(14)");

            builder.Property(p => p.PerfilName)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.DataCriacao)
                .IsRequired();
        }
    }
}
