using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    public String? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public String? Descricao  { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [StringLength(300)]
    public String? ImagemUrl { get; set; }
    [Required]
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    [Required]
    public int CategoriaId { get; set; } // foreign key

    [JsonIgnore]
    public Categoria? Categorias { get; set; }
}