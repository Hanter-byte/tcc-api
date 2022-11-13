using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Manutencoes")]
public class Manutencao
{
    [Key]
    public int ManutencaoId { get; set; }

    [Required]
    [StringLength(80)]
    public String? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    public DateTime DataCadastro { get; set; }
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int ProdutoId { get; set; }

    [JsonIgnore]
    public Cliente? Cliente { get; set; }
    [JsonIgnore]
    public Produto? Produto { get; set; }
}