using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Models;

namespace PizzariaAPI.Data
{
    public class PizzariaDbContext : DbContext
    {
        public PizzariaDbContext(DbContextOptions<PizzariaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<PizzasSabores> PizzasSabores { get; set; }
    }
}
