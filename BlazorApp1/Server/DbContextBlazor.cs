using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace BlazorApp1.Shared
{
    public class DbContextBlazor : DbContext
    {
        public DbContextBlazor(DbContextOptions<DbContextBlazor>options)
            :base(options)
        {
             
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Proyeccion> Proyecciones { get; set; }
        public DbSet<BoletoCompra> BoletosCompras { get; set; }
        //public DbSet<AsientosProyeccionSala> AsientosProyeccionSala { get; set; }


    }
}
