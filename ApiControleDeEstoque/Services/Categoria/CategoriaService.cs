using ApiControleDeEstoque.Context;
using ApiControleDeEstoque.Dto.CategoriaDto;
using ApiControleDeEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiControleDeEstoque.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {

        private readonly AppDbContext _appDbContext;
        public CategoriaService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<ResponseModel<CategoriaModel>> CriarCategoria(CriacaoCategoriaDto criacaoCategoria)
        {
            ResponseModel<CategoriaModel> resposta = new ResponseModel<CategoriaModel>();
            try
            {

                var criarCategoria = new CategoriaModel()
                {
                    CategoriaNome = criacaoCategoria.CategoriaNome
                };

                _appDbContext.Add(criarCategoria);
                await _appDbContext.SaveChangesAsync();
                resposta.Dados = criarCategoria;
                resposta.Mensagem = "Categoria Criada";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<CategoriaModel>> DeletarCategoria(int id)
        {
            ResponseModel<CategoriaModel> resposta = new ResponseModel<CategoriaModel>();
            try
            {
                var deletarCategoria = await _appDbContext.Categorias.FirstOrDefaultAsync(x => x.CategoriaId == id);
                if (deletarCategoria == null)
                {
                    resposta.Dados = deletarCategoria;
                    resposta.Mensagem = "Categoria nao localizada";
                    resposta.Status = false;
                    return resposta;

                }
                _appDbContext.Categorias.Remove(deletarCategoria);
                await _appDbContext.SaveChangesAsync();
                resposta.Dados = deletarCategoria;
                resposta.Mensagem = "Categoria deletada com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<CategoriaModel>> EditarCategoria(EdicaoCategoriaDto edicaoCategoria)
        {
            ResponseModel<CategoriaModel> resposta = new ResponseModel<CategoriaModel>();
            try
            {
                var editarCategoria = new CategoriaModel()
                {
                    CategoriaNome = edicaoCategoria.CategoriaNome,
                };
                _appDbContext.Update(editarCategoria);
                await _appDbContext.SaveChangesAsync();
                resposta.Dados = editarCategoria;
                resposta.Mensagem = "Categoria editada com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<CategoriaModel>>> ListarCategoria()
        {
            ResponseModel<List<CategoriaModel>> resposta = new ResponseModel<List<CategoriaModel>>();
            try
            {
                var categorias = await _appDbContext.Categorias.AsNoTracking().ToListAsync();
                if (categorias is null)
                {
                    resposta.Dados = categorias;
                    resposta.Mensagem = "Lista de Categoria nao localizada";
                    return resposta;
                }
                resposta.Dados = categorias;
                resposta.Mensagem = "Lista de Categoria localizada";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<CategoriaModel>> ListarCategoriaPorId(int id)
        {
            ResponseModel<CategoriaModel> resposta = new ResponseModel<CategoriaModel>();
            try
            {
                var categoriaPorId = await _appDbContext.Categorias.FirstOrDefaultAsync(x => x.CategoriaId == id);
                if (categoriaPorId == null)
                {
                    resposta.Dados = categoriaPorId;
                    resposta.Mensagem = " Categoria nao localizada";
                    return resposta;
                }
                resposta.Dados = categoriaPorId;
                resposta.Mensagem = "Categoria Localizada";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
