using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Shared
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPelicula { get; set; }

        [Required]
        public string? PeliculaUrlImagen { get; set; }

        [Required]
        public string? PeliculaUrlPortada { get; set; }

        [Required]
        public string? Nombre { get; set; }

        public string? Sinopsis { get; set; }
        [Range(0, 10)]
        public float Clasificacion { get; set; }

        //crear tabla N a N para relacionar las peliculas con los generos
        public ICollection<GeneroPelicula>? GeneroPelicula { get; set; }
    }
}
