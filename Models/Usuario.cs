using System.ComponentModel.DataAnnotations;

namespace ClasificadorComents.Models
{
    public class Usuario
    {
        [Key]
        public int Registro { get; set; } 
        public int Contrasena { get; set; } 
    }
}
