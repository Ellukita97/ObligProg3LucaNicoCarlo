using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        [Required]
        public string? Nombre { get; set; }

        //Para relación muchos a muchos
        public ICollection<GeneroPelicula>? GeneroPelicula { get; set; }
    }
}
