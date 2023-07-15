using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Shared
{
    public class Proyeccion
    {
        [Key]
        public int ProyeccionId { get; set; }

        [ForeignKey(nameof(Pelicula))]
        public int PeliculaId { get; set; }
        public Pelicula? Pelicula { get; set; }

        public DateTime FechaHora { get; set; }

        [ForeignKey(nameof(Sala))]
        public int SalaId { get; set; }
        public Sala? Sala { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Monto { get; set; }
    }
}
