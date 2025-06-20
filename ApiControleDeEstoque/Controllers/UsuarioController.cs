using ApiControleDeEstoque.Dto.UsuarioDto;
using ControleDeEstoqueApi.Services.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Registrar([FromBody] CriacaoUsuarioDto dto)
        {
            var resposta = await _usuarioService.RegistrarUsuario(dto);
            if (!resposta.Status) return BadRequest(resposta);
            return Ok(resposta);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _usuarioService.Login(dto);
            if (token == null) return Unauthorized("Email ou senha inválidos");
            return Ok(new { token });
        }

        [HttpGet("listar")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var resposta = await _usuarioService.ListarUsuarios();
            return Ok(resposta);
        }
        [HttpDelete("deletar/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            var resultado = await _usuarioService.DeletarUsuario(id);

            if (!resultado.Status)
                return NotFound(resultado);

            return Ok(resultado);
        }
    }

}

