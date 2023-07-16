using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Falta nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Falta Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Falta Email")]
        [EmailAddress(ErrorMessage = "Email no valido")]
        public string? Email { get; set; }

        [Required]
        public DateTime Fecha_Registro { get; set; }

        [Required]
        public string? Rol { get; set; }

        [Required(ErrorMessage = "Falta Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Falta Telefono")]
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
