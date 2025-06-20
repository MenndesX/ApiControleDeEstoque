using ApiControleDeEstoque.Context;
using ApiControleDeEstoque.Dto.UsuarioDto;
using ApiControleDeEstoque.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleDeEstoqueApi.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _config;

        public UsuarioService(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(CriacaoUsuarioDto dto)
        {
            ResponseModel<UsuarioModel> resposta = new();

            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
            {
                resposta.Mensagem = "Email já cadastrado.";
                resposta.Status = false;
                return resposta;
            }

            var novoUsuario = new UsuarioModel
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                Perfil = dto.Perfil
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            resposta.Mensagem = "Usuário criado com sucesso.";
            resposta.Dados = novoUsuario;
            return resposta;
        }

        public async Task<string?> Login(LoginDto dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash))
            {
                return null;
            }

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            var lista = await _context.Usuarios.ToListAsync();
            return new ResponseModel<List<UsuarioModel>>
            {
                Dados = lista,
                Mensagem = "Usuários encontrados"
            };
        }
        public async Task<ResponseModel<string>> DeletarUsuario(int id)
        {
            ResponseModel<string> resposta = new();

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id);

            if (usuario == null)
            {
                resposta.Status = false;
                resposta.Mensagem = "Usuário não encontrado.";
                return resposta;
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            resposta.Mensagem = "Usuário deletado com sucesso.";
            return resposta;
        }

    }

}
