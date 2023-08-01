using back_mvc_aspNet.Context;
using back_mvc_aspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_mvc_aspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly PruebaMvcContext _context;

        public RegisterController(PruebaMvcContext context)
        {
            _context = context;
        }

        // POST: api/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            try
            {
                // Verificar si el correo electrónico ya está registrado
                var existingUser = await _context.User_.FirstOrDefaultAsync(u => u.Email == registerModel.Email);
                if (existingUser != null)
                {
                    return Ok(new { success = false, message = "El correo electrónico ya está registrado" });
                }

                // Crear un nuevo usuario y guardar en la base de datos
                var newUser = new User
                {
                    Name = registerModel.Name,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email,
                    Password = registerModel.Password
                };

                _context.User_.Add(newUser);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Registro exitoso", data = newUser });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error al procesar la solicitud", error = ex.Message });
            }
        }
    }
}
