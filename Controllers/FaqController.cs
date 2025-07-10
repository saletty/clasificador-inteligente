using Microsoft.AspNetCore.Mvc;
using ClasificadorComents.Models;
using ClasificadorComents.Services;

namespace ClasificadorComents.Controllers
{
    [ApiController]
    [Route("api/faq")]
    public class FaqController : ControllerBase
    {
        private readonly FaqProcessService _service;

        public FaqController(FaqProcessService service)
        {
            _service = service;
        }

        [HttpPost("responder")]
        public IActionResult ResponderPregunta([FromBody] string pregunta)
        {
            if (string.IsNullOrWhiteSpace(pregunta))
                return BadRequest("La pregunta no puede estar vacía.");

            // Busca el proceso según similitud
            var proceso = _service.BuscarProceso(pregunta);

            // Si no hay match, devolvemos un objeto con Steps vacío
            if (proceso == null)
            {
                return Ok(new FaqProcess
                {
                    Title = string.Empty,
                    Intro = "No encontramos una respuesta clara. Por favor, intenta reformular tu pregunta.",
                    Steps = new List<ProcessStep>()
                });
            }
            // Devolvemos el proceso completo (Title, Intro, Steps[])
            return Ok(proceso);
        }
    }
}
