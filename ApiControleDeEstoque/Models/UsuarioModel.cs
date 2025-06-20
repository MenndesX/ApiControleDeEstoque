using ApiControleDeEstoque.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ApiControleDeEstoque.Models
{
    public class UsuarioModel
    {
        [Key]
        public int UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }
        public PerfilEnum Perfil { get; set; }

    }
}
