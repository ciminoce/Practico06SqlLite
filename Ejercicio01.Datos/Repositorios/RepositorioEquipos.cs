using Ejercicio01.Datos.Interfaces;
using Ejercicio01.Entidades;

namespace Ejercicio01.Datos.Repositorios
{
    public class RepositorioEquipos : IRepositorioEquipos
    {
        private readonly ApplicationDbContext _context;

        public RepositorioEquipos(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarEquipo(Equipo equipo)
        {
            try
            {
                _context.Equipos.Add(equipo);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
