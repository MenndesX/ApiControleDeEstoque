using ApiControleDeEstoque.Context;
using ApiControleDeEstoque.Dto.ProdutoDto;
using ApiControleDeEstoque.Models;

using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueApi.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ProdutoModel>> CriarProduto(CriacaoProdutoDto criacaoProduto)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var criarProduto = new ProdutoModel()
                {
                    NomeProduto = criacaoProduto.NomeProduto,
                    Descricao = criacaoProduto.Descricao,
                    Quantidade = criacaoProduto.Quantidade,
                    PrecoCompra = criacaoProduto.PrecoCompra,
                    PrecoVenda = criacaoProduto.PrecoVenda,
                    DataCadastro = criacaoProduto.DataCadastro,
                    CategoriaId = criacaoProduto.CategoriaId,

                };
                _context.Produtos.Add(criarProduto);
                await _context.SaveChangesAsync();

                resposta.Dados = criarProduto;
                resposta.Mensagem = "Produto criado com sucesso";
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

        public async Task<ResponseModel<ProdutoModel>> DeletarProduto(int id)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var deletarProduto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);
                if (deletarProduto == null)
                {
                    resposta.Dados = deletarProduto;
                    resposta.Mensagem = "Produto nao localizado ";
                    resposta.Status = false;
                    return resposta;

                }
                _context.Produtos.Remove(deletarProduto);
                await _context.SaveChangesAsync();

                resposta.Dados = deletarProduto;
                resposta.Mensagem = "Produto deletado";
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

        public async Task<ResponseModel<ProdutoModel>> EditarProduto(EdicaoProdutoDto edicaoProduto)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var editarProduto = new ProdutoModel()
                {
                    NomeProduto = edicaoProduto.NomeProduto,
                    Descricao = edicaoProduto.Descricao,
                    PrecoCompra = edicaoProduto.PrecoCompra,
                    PrecoVenda = edicaoProduto.PrecoVenda
                };

                _context.Update(editarProduto);
                await _context.SaveChangesAsync();

                resposta.Dados = editarProduto;
                resposta.Mensagem = "Produtos Editado";
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

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProduto()
        {
            var resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produto = await _context.Produtos.AsNoTracking().ToListAsync();
                if (produto == null)
                {
                    resposta.Dados = produto;
                    resposta.Mensagem = "Produtos nao localizado";
                    resposta.Status = false;
                }
                resposta.Dados = produto;
                resposta.Mensagem = "Lista de Produtos ";
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

        public async Task<ResponseModel<ProdutoModel>> ProdutoPorId(int id)
        {
            var resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);
                if (produto == null)
                {
                    resposta.Dados = produto;
                    resposta.Mensagem = "Produto id nao localizado";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = produto;
                resposta.Mensagem = "Produto id localido";
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
    }
}
