using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaAPI.Models.ViewModels
{
    public class PizzaSaboresVM
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public List<string> Sabores { get; set; }
    }
}
