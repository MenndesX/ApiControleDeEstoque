using ApiControleDeEstoque.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiControleDeEstoque.Dto.ProdutoDto
{
    public class CriacaoProdutoDto
    {
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        [Required]
        public int CategoriaId { get; set; }


    }
}
