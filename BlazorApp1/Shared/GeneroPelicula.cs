using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Shared
{
    public class GeneroPelicula
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Genero))]
        public int GeneroId { get; set; }

        [ForeignKey(nameof(Pelicula))]
        public int PeliculaId { get; set; }

        public Genero? Genero { get; set; }
        public Pelicula? Pelicula { get; set; }

    }
}
