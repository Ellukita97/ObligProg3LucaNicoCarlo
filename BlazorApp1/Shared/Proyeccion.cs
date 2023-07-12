using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Proyeccion
    {
        [Key]
        public int ProyeccionId { get; set; }

        [Required]
        public Pelicula? Pelicula { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public Sala? Sala { get; set; }

        [Required]
        public int Monto { get; set; }
    }
}
