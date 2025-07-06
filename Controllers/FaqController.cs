using Microsoft.AspNetCore.Mvc;
using ClasificadorComents.Data;
using ClasificadorComents.Models;
using ClasificadorComents.Services;
using ClasificadorComents.Utils; //
using System.Text.Json; //
using System.Threading.Tasks;

namespace ClasificadorComents.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FaqController : ControllerBase
    {
        private readonly OpenAIService _openAIService;

        public FaqController(OpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost("responder")]
        public async Task<IActionResult> ResponderPregunta([FromBody] string pregunta)
        {
            if (string.IsNullOrWhiteSpace(pregunta))
                return BadRequest("La pregunta no puede estar vacía.");

            var respuesta = await _openAIService.ObtenerRespuestaAsync(pregunta);

            return Ok(new { Respuesta = respuesta });
        }
    }
}
