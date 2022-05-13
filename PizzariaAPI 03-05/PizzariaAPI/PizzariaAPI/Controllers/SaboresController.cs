using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzariaAPI.Data;
using PizzariaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaboresController : ControllerBase
    {
        private PizzariaDbContext _context;

        public SaboresController(PizzariaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<Sabor> GetSabores()
        {
            return Ok(_context.Sabores);
        }

        [HttpPost]
        public ActionResult<Sabor> PostSabor(Sabor sabor)
        {
            _context.Sabores.Add(sabor);
            _context.SaveChanges();

            return CreatedAtAction("PostSabor", sabor);
        }
    }
}
