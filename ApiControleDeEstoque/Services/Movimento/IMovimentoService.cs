using ApiControleDeEstoque.Dto.MovimentoDto;
using ApiControleDeEstoque.Models;

namespace ControleDeEstoqueApi.Services.Movimento
{
    public interface IMovimentoService
    {

        Task<ResponseModel<MovimentoEstoqueModel>> CriarMovimento(CriacaoMovimentoDto dto);
        Task<ResponseModel<List<MovimentoEstoqueModel>>> ListarMovimentos();


    }
}
