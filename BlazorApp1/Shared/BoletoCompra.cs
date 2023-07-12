using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class BoletoCompra
    {
        [Key]
        public int IdBoleto { get; set; }

        //Relacion entre una tabla con otra cuya clave primaria esta formada por mas de un campo
        /*
        [Required]
        public Proyeccion? Proyeccion { get; set; } 
        */
        [Required]
        public Usuario? Usuario { get; set; }
        [Required]
        public int Asiento { get; set; }
    }
}
