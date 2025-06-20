using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiControleDeEstoque.Models
{
    public class ProdutoModel
    {
        [Key]
        public int ProdutoId { get; set; }
        [Required]
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public double PrecoCompra { get; set; }
        public double PrecoVenda { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        [JsonIgnore]
        public CategoriaModel Categoria { get; set; }

    }
}
