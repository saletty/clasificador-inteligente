using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClasificadorComents.Models
{
    [Table("pregunta_frecuente")] // <-- usa el nombre real de la tabla
    public class PregFrec
    {
        [Key]
        public int Id { get; set; }
        public string Pregunta_Ejemplo { get; set; }
        public string Categoria { get; set; }
        public string Respuesta { get; set; }
    }
}
