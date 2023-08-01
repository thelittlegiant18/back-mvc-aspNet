using System.ComponentModel.DataAnnotations;

namespace back_mvc_aspNet.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El campo 'Email' es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'Password' es requerido.")]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = null!;
    }
}
