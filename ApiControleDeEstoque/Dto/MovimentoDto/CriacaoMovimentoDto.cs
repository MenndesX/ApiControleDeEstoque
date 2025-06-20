using System.ComponentModel.DataAnnotations;

namespace ApiControleDeEstoque.Dto.MovimentoDto
{
    public class CriacaoMovimentoDto
    {
        [Required]
        public string TipoMovimentacao { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public string Observacao { get; set; }

        [Required]
        public int ProdutoId { get; set; }


    }
}
