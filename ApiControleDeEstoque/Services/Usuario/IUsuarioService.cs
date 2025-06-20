using ApiControleDeEstoque.Dto.UsuarioDto;
using ApiControleDeEstoque.Models;


namespace ControleDeEstoqueApi.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(CriacaoUsuarioDto dto);
        Task<string> Login(LoginDto dto);
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<string>> DeletarUsuario(int id);


    }
}
