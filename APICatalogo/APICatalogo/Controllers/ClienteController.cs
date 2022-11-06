using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return _context.Clientes.ToList();
        }
        [HttpGet("{id:int}", Name = "ObterClientes")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);
            if (cliente is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return cliente;
        }
        [HttpPost]
        public ActionResult Post(Cliente cliente)
        {
            if (cliente is null)
                return BadRequest();
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = cliente.ClienteId }, cliente);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(cliente);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);
            if (cliente is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok(cliente);
        }
    }
}