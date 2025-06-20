using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiControleDeEstoque.Models
{
    public class CategoriaModel
    {

        [Key]
        public int CategoriaId { get; set; }
        [Required]
        public string? CategoriaNome { get; set; }
        public Collection<ProdutoModel>? Produtos { get; set; }

    }
}

