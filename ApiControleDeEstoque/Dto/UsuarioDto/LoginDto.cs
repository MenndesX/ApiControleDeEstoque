﻿using System.ComponentModel.DataAnnotations;

namespace ApiControleDeEstoque.Dto.UsuarioDto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
