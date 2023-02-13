using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Clientes")]
public class Cliente
{
    [Key]
    public int ClienteId { get; set; }

    [Required]
    [StringLength(11)]
    public string? Cpf { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    public DateTime DataCadastro { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string? Email { get; set; }

    [Required]
    public int  Telefone { get; set; }
}