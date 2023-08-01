using back_mvc_aspNet.Context;
using back_mvc_aspNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_mvc_aspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PruebaMvcContext _context;

        public LoginController(PruebaMvcContext context)
        {
            _context = context;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                var user = await _context.User_.FirstOrDefaultAsync(u => u.Email == loginModel.Email && u.Password == loginModel.Password);

                if (user != null)
                {
                    // Autenticación exitosa, devolver un token JWT u otra lógica de sesión
                    return Ok(new { success = true, message = "Inicio de sesión exitoso", data = user });
                }
                else
                {
                    // Credenciales inválidas, devolver estado HTTP 401 (Unauthorized)
                    return Ok(new { success = false, message = "Credenciales inválidas" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error al procesar la solicitud", error = ex.Message });
            }
        }
    }
}
