using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class AsientosProyeccionSala
    {
        [ForeignKey(nameof(Sala))]
        public int IdSala { get; set; }
        [NotMapped]
        public Sala? Sala { get; set; }


        [ForeignKey(nameof(Proyeccion))]
        public int IdProyeccion { get; set; }
        [NotMapped]
        public Proyeccion? Proyeccion { get; set; }

        public int AsientoDisponible { get; set; }
    }
}
