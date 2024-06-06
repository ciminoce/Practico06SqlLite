using Ejercicio01.Datos.Interfaces;
using Ejercicio01.Entidades;
using Ejercicio01.Ioc;
using Microsoft.Extensions.DependencyInjection;
using MiDLL;

namespace Ejercicio01.Consola
{
   
    internal class Program
    {
        private static IServiceProvider? _serviceProvider;
        static void Main(string[] args)
        {
            _serviceProvider = DI.ConfigurarServicios();
            var repoEquipo = _serviceProvider.GetService<IRepositorioEquipos>();
            Console.WriteLine("Creacion de Equipos");
            string nombreEquipo = ConsoleExtensions.ReadString("Ingrese el nombre del equipo:");
            int cantidadJugadores = ConsoleExtensions.ReadInt("Ingrese la cantidad de Jugadores del equipo:");
            Equipo equipo = CrearEquipo(nombreEquipo, cantidadJugadores);
            repoEquipo.AgregarEquipo(equipo);
            ContratarJugadores(equipo);
            MostrarDatosDelEquipo(equipo);
            ConsoleExtensions.EsperarPresionDeTecla();
        }

        private static void MostrarDatosDelEquipo(Equipo equipo)
        {
            Console.WriteLine((string)equipo);
        }

        private static void ContratarJugadores(Equipo equipo)
        {
            var repoJugador = _serviceProvider.GetService<IRepositorioJugadores>();
            do
            {
                Jugador jugador = CrearJugador(equipo);
                if (equipo + jugador)
                {
                    Console.WriteLine($"{jugador.MostrarDatos()} contratado");
                    try
                    {
                        repoJugador.AgregarJugador(jugador);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    Console.WriteLine($"Jugador existente o no hay cupo");
                }

            } while (equipo.GetCantidad() < equipo.GetCantidadJugadores());
        }

        private static Jugador CrearJugador(Equipo equipo)
        {
            var dni = ConsoleExtensions.ReadInt("Ingrese el DNI:");
            var nombre = ConsoleExtensions.ReadString("Ingrese el nombre del jugador:");
            return new Jugador(dni, nombre,equipo.EquipoId);
        }

        private static Equipo CrearEquipo(string nombreEquipo, int cantidadJugadores)
        {
            return new Equipo(nombreEquipo, cantidadJugadores);
        }

    }
}
