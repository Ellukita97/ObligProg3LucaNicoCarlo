using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPelicula { get; set; }

        [Required]
        public string? PeliculaUrlImagen{ get; set; }

        [Required]
        public string? Nombre { get; set; }

        //crear tabla N a N para relacionar las peliculas con los generos
        //public List<Genero>? Generos { get; set; }
        public string? Sinopsis { get; set; }
        public float Clasificacion { get; set; }
    }
}
