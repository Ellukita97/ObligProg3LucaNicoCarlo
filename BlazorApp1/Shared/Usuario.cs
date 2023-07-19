using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre requerido")]
        public string? Nombre { get; set; }


        [Required(ErrorMessage = "Contraseña requerida")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Email requerido")]
        [EmailAddress(ErrorMessage = "Formato de email incorrecto")]
        public string? Email { get; set; }

        [Required]
        public DateTime Fecha_Registro { get; set; }

        [Required]
        public string? Rol { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Telefono requerido")]
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
