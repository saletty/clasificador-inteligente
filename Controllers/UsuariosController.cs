using ClasificadorComents.Data;
using ClasificadorComents.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClasificadorComents.Controllers
{
    
        [ApiController]
        [Route("api/usuario")]
        public class UsuariosController : ControllerBase
        {
            private readonly AppDbContext _context;

            public UsuariosController(AppDbContext context)
            {
                _context = context;
            }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario login)
        {
              //return Ok("Sí llegó al backend");

            var usuario = _context.Usuario
                .FirstOrDefault(u => u.Registro == login.Registro && u.Contrasena == login.Contrasena);

            if (usuario == null)
                return Unauthorized("Credenciales inválidas");

            return Ok(new { mensaje = "Inicio de sesión exitoso", usuarioId = usuario.Registro });
        }
        
    }

}
