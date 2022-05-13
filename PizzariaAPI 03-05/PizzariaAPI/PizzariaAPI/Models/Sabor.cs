using System.Collections.Generic;

namespace PizzariaAPI.Models
{
    public class Sabor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PizzasSabores> PizzasSabores { get; set; }
    }
}
