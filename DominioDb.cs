using Microsoft.EntityFrameworkCore;

namespace DominiosAPI
{
    public class DominioDb : DbContext
    {
        // Reference our tomato table using this
        public DbSet<Dominio> Dominios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Dominios.db");
        }

    }
}