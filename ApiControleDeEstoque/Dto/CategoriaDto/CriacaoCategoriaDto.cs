using System.ComponentModel.DataAnnotations;

namespace ApiControleDeEstoque.Dto.CategoriaDto
{
    public class CriacaoCategoriaDto
    {
        [Required(ErrorMessage = "O campo Categoria é obrigatório")]
        public string? CategoriaNome { get; set; }
    }
}
