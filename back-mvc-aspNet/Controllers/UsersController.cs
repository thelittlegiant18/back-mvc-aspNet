using back_mvc_aspNet.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_mvc_aspNet.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly PruebaMvcContext _context;

        public UsersController(PruebaMvcContext context)
        {
            _context = context;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _context.User_.ToListAsync();
                return Ok(new {success = true, message = "Usuarios listados correctamente", data = users });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = "Error al listar los datos de los usuarios", error = ex.Message });
            }
        }
    }
}
