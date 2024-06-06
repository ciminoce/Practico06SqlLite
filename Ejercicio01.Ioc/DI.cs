using Ejercicio01.Datos;
using Ejercicio01.Datos.Interfaces;
using Ejercicio01.Datos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ejercicio01.Ioc
{
    public static class DI
    {
        public static IServiceProvider? ConfigurarServicios()
        {
            var servicios = new ServiceCollection();
            servicios.AddScoped<IRepositorioEquipos, 
                RepositorioEquipos>();
            servicios.AddScoped<IRepositorioJugadores,
                RepositorioJugadores>();
            servicios.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite("Data Source=BD.db");
            });
            return servicios.BuildServiceProvider();
        }
    }
}
