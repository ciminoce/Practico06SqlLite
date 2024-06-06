using System.Text;

namespace Ejercicio01.Entidades
{
    public class Equipo
    {
        private int equipoId;
        private int cantidadJugadores;
        private List<Jugador> jugadores;
        private string nombre = null!;

        public int EquipoId { get => equipoId; set => equipoId = value; }
        public int CantidadJugadores { get => cantidadJugadores; set => cantidadJugadores = value; }
        public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        private Equipo()
        {
            jugadores = new List<Jugador>();
        }
        public Equipo(string nombreE, int cantidad) : this()
        {
            Nombre = nombreE;
            CantidadJugadores = cantidad > 0 ? cantidad : 3;
        }
        public int GetCantidadJugadores() => cantidadJugadores;
        public static bool operator +(Equipo e, Jugador j)
        {
            if (e is null || j is null) return false;
            if (e.jugadores?.Count == e.GetCantidadJugadores())
            {
                return false;
            }
            if (e != j)
            {
                e.jugadores?.Add(j);
                return true;
            }
            return false;
        }
        public static bool operator ==(Equipo e, Jugador j)
        {
            if (e is null || j is null) return false;
            if (e.jugadores is null)
            {
                return false;
            }
            if (e.GetCantidad() == 0)
            {
                return false;
            }
            if (e.jugadores.Contains(j))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static explicit operator string(Equipo e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre Equipo:{e.Nombre}");
            sb.AppendLine($"(Jugadores):");
            string jugadoresEquipo = string.Empty;
            if (e.jugadores != null && e.jugadores.Count > 0)
            {
                jugadoresEquipo = string.Join(Environment.NewLine,
                    e.jugadores.Select(j => j.MostrarDatos()));
            }
            else
            {
                jugadoresEquipo = "Sin Jugadores";
            }
            sb.AppendLine(jugadoresEquipo);
            return sb.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Equipo equipo)) return false;
            if (Nombre != equipo.Nombre) return false;

            if (GetCantidadJugadores() != equipo.GetCantidadJugadores()) return false;
            if (GetCantidad() != equipo.GetCantidad()) return false;
            return Nombre == equipo.Nombre &&
                GetCantidadJugadores() == equipo.GetCantidadJugadores() &&
                jugadores.SequenceEqual(equipo.jugadores);

        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash += 23 * Nombre.GetHashCode();
                if (jugadores is not null)
                {
                    foreach (var j in jugadores)
                    {
                        hash += 23 * j.GetHashCode();
                    }

                }
                return hash;
            }
        }

        public int GetCantidad() => jugadores?.Count ?? 0;
    }
}
