using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Scouter.ApplicationCore.Entities;
using Scouter.Infrastructure.Extensions;
using Scouter.Infrastructure.Mappings;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Scouter.Infrastructure.Context
{
    public class ScouterContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Position> Position { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new UsuarioMapping());
            modelBuilder.AddConfiguration(new LevelMapping());
            modelBuilder.AddConfiguration(new PositionMapping());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ScouterConnection"));
        }
    }
}
