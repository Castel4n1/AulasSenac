namespace PizzariaAPI.Models
{
    public class PizzasSabores
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public int SaborId { get; set; }
        public Sabor Sabor { get; set; }
    }
}
