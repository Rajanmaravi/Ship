using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cargo>? Cargos { get; set; }
        public DbSet<Ship>? Ships { get; set; }
    }
}