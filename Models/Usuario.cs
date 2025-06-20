using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClasificadorComents.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Registro { get; set; } 
        public int Contrasena { get; set; }
    }
}
