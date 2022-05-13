using System.Collections.Generic;

namespace PizzariaAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public List<PizzasSabores> PizzasSabores { get; set; }
    }
}