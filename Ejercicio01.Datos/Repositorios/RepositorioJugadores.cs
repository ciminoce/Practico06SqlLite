using Ejercicio01.Datos.Interfaces;
using Ejercicio01.Entidades;

namespace Ejercicio01.Datos.Repositorios
{
    public class RepositorioJugadores : IRepositorioJugadores
    {
        private readonly ApplicationDbContext _context;

        public RepositorioJugadores(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AgregarJugador(Jugador jugador)
        {
            try
            {
                _context.Jugadores.Add(jugador);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
