using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace APICatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet] //Retorna todos os dados
    public ActionResult<IEnumerable<Produto>> Get()
    {
        // var produtos = _context.Produtos.Take(2).ToList();
        var produtos = _context.Produtos.ToList();
        if (produtos is null)
        {
            return NotFound("Produtos não encontrados..."); //Equivalente ao erro 404
        }
        return produtos;
    }
    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")] // Retorna o dado relacionado ao ID
    public ActionResult<Produto> Get(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
        {
            return NotFound("Produto não encontrado...");
        }
        return produto;
    }
    [HttpPost] //Cria um novo Produto
    public ActionResult Post(Produto produto)
    {
        if (produto is null)
            return BadRequest();
        _context.Produtos?.Add(produto);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
    }
    [HttpPut("{id:int}")] //Altera Produto
    public ActionResult Put(int id, Produto produto)
    {
        if(id != produto.ProdutoId)
        {
            return BadRequest();
        }
        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }
    [HttpDelete("{id:int}")] //Remove o Produto
    public ActionResult Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        if(produto is null)
        {
            return NotFound("Produto não localizado...");
        }
        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok(produto);
    }
}