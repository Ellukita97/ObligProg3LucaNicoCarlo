using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Shared
{
    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPelicula { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? PeliculaUrlImagen { get; set; }

        public string? PeliculaUrlPortada { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string? Sinopsis { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Range(0, 10)]
        public float Clasificacion { get; set; }

        //crear tabla N a N para relacionar las peliculas con los generos
        public ICollection<GeneroPelicula>? GeneroPelicula { get; set; }
    }
}
