using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace back_mvc_aspNet.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "El campo 'Name' es requerido.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'LastName' es requerido.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'Email' es requerido.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido.")]
        [MinLength(20, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El campo 'Password' es requerido.")]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 6 caracteres.")]
        public string Password { get; set; } = null!;
    }
}
