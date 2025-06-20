using ApiControleDeEstoque.Dto.CategoriaDto;
using ApiControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDeEstoque.Services.Categoria
{
    public interface ICategoriaService
    {
        Task<ResponseModel<List<CategoriaModel>>> ListarCategoria();
        Task<ResponseModel<CategoriaModel>> ListarCategoriaPorId(int id);
        Task<ResponseModel<CategoriaModel>> CriarCategoria(CriacaoCategoriaDto criacaoCategoria);
        Task<ResponseModel<CategoriaModel>> EditarCategoria(EdicaoCategoriaDto edicaoCategoria);
        Task<ResponseModel<CategoriaModel>> DeletarCategoria(int id);


    }
}
