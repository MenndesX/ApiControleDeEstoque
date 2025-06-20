using ApiControleDeEstoque.Models.Enums;
using System.ComponentModel.DataAnnotations;

public class CriacaoUsuarioDto
{
    [Required]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }

    public PerfilEnum Perfil { get; set; } = PerfilEnum.Usuario;
}
