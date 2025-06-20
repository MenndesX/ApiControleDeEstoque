using System.ComponentModel.DataAnnotations;

namespace ApiControleDeEstoque.Dto.ProdutoDto
{
    public class EdicaoProdutoDto
    {
        [Required]
        public string NomeProduto { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
    }
}
