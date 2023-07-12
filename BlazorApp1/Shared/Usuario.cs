using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp1.Shared
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Contrasenia { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string? Email { get; set; }

        [Required]
        public DateTime Fecha_Registro { get; set; }

        [Required]
        public string? TipoUsuario { get; set;}

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string? Tel {get; set;}
    }
}
