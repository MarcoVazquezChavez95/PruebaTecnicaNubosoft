using System.Data.Entity;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}