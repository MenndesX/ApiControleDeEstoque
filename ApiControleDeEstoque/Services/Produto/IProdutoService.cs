using ApiControleDeEstoque.Dto.ProdutoDto;
using ApiControleDeEstoque.Models;

namespace ControleDeEstoqueApi.Services.Produto
{
    public interface IProdutoService
    {

        Task<ResponseModel<List<ProdutoModel>>> ListarProduto();
        Task<ResponseModel<ProdutoModel>> ProdutoPorId(int id);
        Task<ResponseModel<ProdutoModel>> CriarProduto(CriacaoProdutoDto criacaoCategoria);
        Task<ResponseModel<ProdutoModel>> EditarProduto(EdicaoProdutoDto edicaoCategoria);
        Task<ResponseModel<ProdutoModel>> DeletarProduto(int id);
    }
}
