using Microsoft.EntityFrameworkCore;
using ClasificadorComents.Models;

namespace ClasificadorComents.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<PregFrec> Pregunta_Frecuente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
