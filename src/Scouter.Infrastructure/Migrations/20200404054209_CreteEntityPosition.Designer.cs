﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scouter.Infrastructure.Context;

namespace Scouter.Infrastructure.Migrations
{
    [DbContext(typeof(ScouterContext))]
    [Migration("20200404054209_CreteEntityPosition")]
    partial class CreteEntityPosition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Scouter.ApplicationCore.Entities.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("LevelNameNote")
                        .HasColumnType("varchar(8000)");

                    b.HasKey("Id");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("Scouter.ApplicationCore.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<string>("PositionName");

                    b.Property<string>("PositionNameNote");

                    b.HasKey("Id");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("Scouter.ApplicationCore.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<bool>("Bloqueado");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PerfilName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(14)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
