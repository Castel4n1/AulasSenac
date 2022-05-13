using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.Data;
using PizzariaAPI.Models;
using PizzariaAPI.Models.ViewModels;
using System.Linq;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private PizzariaDbContext _context;

        public PizzasController(PizzariaDbContext context)
        {
            _context = context;
        }

        [HttpGet("chama-pizzas-sem-sabores")]
        public ActionResult<Pizza> GetPizzas()
        {
            return Ok(_context.Pizzas);
        }

        [HttpGet("pizzas-sabores")]
        public ActionResult<PizzaSaboresVM> GetPizzasComSabores()
        {
            var pizzas = _context.Pizzas
                .Select(x => new PizzaSaboresVM()
                {
                    Nome = x.Nome,
                    Preco = x.Preco,
                    Sabores = _context.PizzasSabores
                        .Where(ps => ps.Pizza.Id == x.Id)
                        .Select(ps => ps.Sabor.Nome)
                        .ToList()
                });

            return Ok(pizzas);
        }

        [HttpPost]
        public ActionResult<Pizza> PostPizza(PizzaVM pizza)
        {
            //instanciei uma pizza entidade do banco
            Pizza p1 = new Pizza()
            {
                //adicionei os dados que recebi nessa entidade
                Nome = pizza.Nome,
                Preco = pizza.Preco
            };

            _context.Pizzas.Add(p1); //adicionei ao banco
            _context.SaveChanges(); //commitei mudanças no bd

            return CreatedAtAction("PostPizza", p1); //devolvi dados
        }

        [HttpPost("cadastrar-pizza-com-sabor")]
        public PizzaSaboresVM PostPizzaSabor(PizzaSaboresVM pizzaSabores)
        {
            Pizza p1 = new Pizza()
            {
                Nome = pizzaSabores.Nome,
                Preco = pizzaSabores.Preco
            };



            _context.Pizzas.Add(p1);
            _context.SaveChanges();


            //explicação em áudio
            foreach(var sabor in pizzaSabores.Sabores)
            {
                PizzasSabores ps = new PizzasSabores()
                {
                    PizzaId = p1.Id,
                    SaborId = _context.Sabores.FirstOrDefault(s => 
                            s.Nome == sabor).Id
                };

                _context.PizzasSabores.Add(ps);
                _context.SaveChanges();

            }
            // RETORNAR OS DADOS DE FORMA BONITINHA.
            // NEW PIZZASABORESVM (); INSTANCIAR ISSO E RETORNAR.

            var retorno = new PizzaSaboresVM()
            {
                Nome = p1.Nome,
                Preco = p1.Preco,
                Sabores = _context.PizzasSabores
                    .Where(ps => ps.Pizza.Id == p1.Id)
                    .Select(ps => ps.Sabor.Nome)
                    .ToList()
            };

            return retorno;

        }


    }
}
        
        
        
