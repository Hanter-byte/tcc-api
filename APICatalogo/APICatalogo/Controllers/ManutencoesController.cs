using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManutencoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManutencoesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Manutencao>> Get()
        {
            return _context.Manutencaos.ToList();
        }
        [HttpGet("{id:int}", Name = "ObterManutencao")]
        public ActionResult<Manutencao> Get(int id)
        {
            var manutencao = _context.Manutencaos.FirstOrDefault(p => p.ManutencaoId == id);
            if (manutencao is null)
            {
                return NotFound("Manutenção não encontrada...");
            }
            return manutencao;
        }
        [HttpPost]
        public ActionResult Post(Manutencao manutencao)
        {
            if (manutencao is null)
                return BadRequest();
            _context.Manutencaos.Add(manutencao);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterManutencao", new { id = manutencao.ManutencaoId}, manutencao);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Manutencao manutencao)
        {
            if (id != manutencao.ManutencaoId)
            {
                return BadRequest();
            }
            _context.Entry(manutencao).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(manutencao);
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var manutencao = _context.Manutencaos.FirstOrDefault(p => p.ManutencaoId == id);
            if (manutencao is null)
            {
                return NotFound("Manutenção não localizada...");
            }
            _context.Manutencaos.Remove(manutencao);
            _context.SaveChanges();

            return Ok(manutencao);
        }
    }
}