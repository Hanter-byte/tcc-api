using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models; //novo recurso ";"

[Table("Categorias")]
public class Categoria
{

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public String? Nome { get; set; } //? identifica as propriedades como nulas

    [Required]
    [StringLength(300)]
    public String? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; }
}