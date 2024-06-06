using Ejercicio01.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Ejercicio01.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.ToTable("Equipos");
                entity.HasMany(e => e.Jugadores)
                    .WithOne()
                    .HasForeignKey(j => j.EquipoId);
            });
            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.ToTable("Jugadores");
                entity.HasKey(j => j.JugadorId);
                entity.HasOne(j => j.Equipo)
                    .WithMany(e => e.Jugadores);
            });
        }
    }
}
