using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? DescGenero { get; set; }
    }
}
