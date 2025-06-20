using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClasificadorComents.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public string Registro { get; set; } 
        public string Contrasena { get; set; }
    }
}
