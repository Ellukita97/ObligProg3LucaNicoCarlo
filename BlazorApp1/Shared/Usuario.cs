using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime Fecha_Registro { get; set; }

        [Required]
        public string? Rol { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string? Tel { get; set; }

        public Usuario()
        {

        }
        public Usuario(DateTime pdatetime, string Rol)
        {
            this.Fecha_Registro = pdatetime;
            this.Rol = Rol;
        }
    }
}
