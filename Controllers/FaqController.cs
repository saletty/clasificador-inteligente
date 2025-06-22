using Microsoft.AspNetCore.Mvc;
using ClasificadorComents.Data;
using ClasificadorComents.Models;
using ClasificadorComents.Services;
using ClasificadorComents.Utils; //
using System.Text.Json; //

namespace ClasificadorComents.Controllers
{
    [ApiController]
    [Route("api/faq")]
    public class FaqController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly OpenAIService _openAIService; // Inyecta el servicio OpenAI si lo necesitas

        public FaqController(AppDbContext context, OpenAIService openAIService) //
        {
            _context = context;
            _openAIService = openAIService; //
        }

        // DTO para recibir el objeto JSON con la propiedad "pregunta"
        public class PreguntaDTO
        {
            public string Pregunta { get; set; }
        }


        [HttpPost("responder")]
        public async Task<IActionResult> ResponderPregunta([FromBody] PreguntaDTO data)
        {
            if (string.IsNullOrWhiteSpace(data.Pregunta))
                return BadRequest("La pregunta está vacía");

            var embeddingUsuario = await _openAIService.ObtenerEmbeddingAsync(data.Pregunta);

            var preguntas = _context.Pregunta_Frecuente.ToList();

            double maxSimilitud = -1;
            PregFrec mejorCoincidencia = null;

            foreach (var pregunta in preguntas)
            {
                if (string.IsNullOrEmpty(pregunta.Embedding))
                    continue;

                var embeddingGuardado = JsonSerializer.Deserialize<List<float>>(pregunta.Embedding);
                var similitud = CosineSimilarity.Calcular(embeddingUsuario, embeddingGuardado);

                if (similitud > maxSimilitud)
                {
                    maxSimilitud = similitud;
                    mejorCoincidencia = pregunta;
                }
            }

            if (maxSimilitud >= 0.75 && mejorCoincidencia != null)
                return Ok(new { respuesta = mejorCoincidencia.Respuesta,
                    similitud = maxSimilitud,
                    preguntaCoincidente = mejorCoincidencia.Pregunta_Ejemplo
                });

            return Ok(new { mensaje = "No se encontró una respuesta adecuada.",
                //"Lo siento, no encontré una respuesta adecuada. Un agente te contactará pronto.", 
                similitud = maxSimilitud,
                preguntaCoincidente = mejorCoincidencia?.Pregunta_Ejemplo});
        }

        [HttpPost("generar-embeddings")]
        public async Task<IActionResult> GenerarEmbeddings()
        {
            var preguntas = _context.Pregunta_Frecuente.ToList();
            int actualizadas = 0;

            foreach (var pregunta in preguntas)
            {
                if (!string.IsNullOrEmpty(pregunta.Embedding))
                    continue;

                try
                {
                    var embedding = await _openAIService.ObtenerEmbeddingAsync(pregunta.Pregunta_Ejemplo);
                    pregunta.Embedding = JsonSerializer.Serialize(embedding);
                    actualizadas++;
                }
                catch (Exception ex)
                {
                    // Maneja o registra el error
                }
            }

            await _context.SaveChangesAsync();

            return Ok($"{actualizadas} preguntas actualizadas con embeddings.");
        }

        /*[HttpPost("responder")]
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
        }*/
    }
}

