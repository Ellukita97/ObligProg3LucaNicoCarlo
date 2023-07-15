using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Shared
{
    [Index(nameof(IdSala), nameof(IdProyeccion), IsUnique = true)]
    public class AsientosProyeccionSala
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sala")]
        public int IdSala { get; set; }
        public Sala? Sala { get; set; }

        [ForeignKey("Proyeccion")]
        public int IdProyeccion { get; set; }
        public Proyeccion? Proyeccion { get; set; }

        public int AsientoDisponible { get; set; }
    }
}
