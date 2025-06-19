using Microsoft.AspNetCore.Mvc;
using ClasificadorComents.Data;
using ClasificadorComents.Models;

namespace ClasificadorComents.Controllers
{
    [ApiController]
    [Route("api/faq")]
    public class FaqController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FaqController(AppDbContext context)
        {
            _context = context;
        }

        // DTO para recibir el objeto JSON con la propiedad "pregunta"
        public class PreguntaDTO
        {
            public string Pregunta { get; set; }
        }

        [HttpPost("responder")]
        public IActionResult ResponderPregunta([FromBody] PreguntaDTO data)
        {
            if (string.IsNullOrWhiteSpace(data.Pregunta))
                return BadRequest("La pregunta está vacía");

            var preguntaLower = data.Pregunta.ToLower();

            var coincidencia = _context.Pregunta_Frecuente
                .ToList()
                .FirstOrDefault(faq => preguntaLower.Contains(faq.Pregunta_Ejemplo.ToLower()));

            if (coincidencia != null)
                return Ok(coincidencia.Respuesta);

            return Ok("Lo siento, no encontré una respuesta exacta. Un agente te contactará pronto.");
        }
    }
}

