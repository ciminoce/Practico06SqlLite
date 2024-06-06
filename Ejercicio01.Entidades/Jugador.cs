namespace Ejercicio01.Entidades
{
    public class Jugador
    {
        private int equipoId;
        private int jugadorId;
        private int dni;
        private string nombre = null!;
        private int partidosJugados;
        private int totalGoles;
        private double promedioGoles;

        public int EquipoId { get => equipoId; set => equipoId = value; }
        public int JugadorId { get => jugadorId; set => jugadorId = value; }
        public int Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int PartidosJugados { get => partidosJugados; set => partidosJugados = value; }
        public int TotalGoles { get => totalGoles; set => totalGoles = value; }
        public Equipo Equipo { get; set; }
        public Jugador()
        {
            TotalGoles = 0;
            PartidosJugados = 20;

        }
        public Jugador(int dniJ, string nombreJ,
            int partidosJ, int golesJ, int equipoId)
        {
            EquipoId=equipoId;
            Dni = dniJ;
            Nombre = nombreJ;
            TotalGoles = golesJ;
            PartidosJugados = partidosJ;
        }
        public Jugador(int dniJ, string nombreJ, int equipoId) : this(dniJ,
            nombreJ, 20, 0, equipoId)
        {

        }
        public double GetPromedioGoles()
        {
            promedioGoles = TotalGoles / PartidosJugados;
            return promedioGoles;
        }
        public string MostrarDatos()
        {
            return $"{Dni} - {Nombre} - {PartidosJugados} - {TotalGoles} - {GetPromedioGoles()}";
        }

        public static bool operator ==(Jugador j1, Jugador j2)
        {
            if (j1 is null || j2 is null)
            {
                return false;
            }
            return j1.Dni == j2.Dni;
        }
        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is Jugador jugador)) return false;
            return this == jugador;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                return hash += 23 * Dni.GetHashCode();
            }
        }
    }
}
