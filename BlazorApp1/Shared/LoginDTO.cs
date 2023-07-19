using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared
{
    public class LoginDTO
    {
        [EmailAddress(ErrorMessage = "Formato de email incorrecto")]
        [Required(ErrorMessage = "Error, email requerido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Error, Contraseña requerida")]
        public string? Password { get; set; }
    }
}
