using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiControleDeEstoque.Models
{
    public class MovimentoEstoqueModel
    {
        [Key]
        public int MovimentoId { get; set; }
        [Required]
        public string TipoMovimentacao { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string? Observacao { get; set; }

        [Required]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public ProdutoModel Produto { get; set; }
    }
}
