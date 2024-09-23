using GestionEquipo.DB.DATA.ENTITY;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEquipo.DB.DATA
{
    public class Context : DbContext
    {
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Entrenamiento> Entrenamientos { get; set; }
        public DbSet<AsistEntrenamiento> AsistEntrenamientos { get; set; }
        public DbSet<EstPartido> EstPartidos { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }
          
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
