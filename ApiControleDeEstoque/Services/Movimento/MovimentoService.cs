using ApiControleDeEstoque.Context;
using ApiControleDeEstoque.Dto.MovimentoDto;
using ApiControleDeEstoque.Models;

using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoqueApi.Services.Movimento
{

    public class MovimentoService : IMovimentoService
    {
        private readonly AppDbContext _context;
        public MovimentoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<MovimentoEstoqueModel>> CriarMovimento(CriacaoMovimentoDto dto)
        {

            ResponseModel<MovimentoEstoqueModel> resposta = new ResponseModel<MovimentoEstoqueModel>();

            try
            {

                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == dto.ProdutoId);

                if (produto == null)
                {
                    resposta.Mensagem = "Produto não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }


                if (dto.TipoMovimentacao.ToLower() == "entrada")
                {

                    produto.Quantidade += dto.Quantidade;
                }
                else if (dto.TipoMovimentacao.ToLower() == "saida")
                {

                    if (produto.Quantidade < dto.Quantidade)
                    {
                        resposta.Mensagem = "Estoque insuficiente para essa saída.";
                        resposta.Status = false;
                        return resposta;
                    }


                    produto.Quantidade -= dto.Quantidade;
                }
                else
                {

                    resposta.Mensagem = "Tipo de movimentação inválido. Use 'entrada' ou 'saida'.";
                    resposta.Status = false;
                    return resposta;
                }


                var movimento = new MovimentoEstoqueModel
                {
                    TipoMovimentacao = dto.TipoMovimentacao,
                    Quantidade = dto.Quantidade,
                    Observacao = dto.Observacao,
                    ProdutoId = dto.ProdutoId,
                    Data = DateTime.Now
                };


                _context.Movimentos.Add(movimento);
                _context.Produtos.Update(produto);

                await _context.SaveChangesAsync();


                resposta.Dados = movimento;
                resposta.Mensagem = "Movimentação registrada com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = $"Erro: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<MovimentoEstoqueModel>>> ListarMovimentos()
        {
            ResponseModel<List<MovimentoEstoqueModel>> resposta = new();

            try
            {
                var movimentos = await _context.Movimentos
                    .Include(m => m.Produto)
                    .AsNoTracking()
                    .ToListAsync();

                if (movimentos == null || movimentos.Count == 0)
                {
                    resposta.Mensagem = "Nenhuma movimentação encontrada.";
                    resposta.Status = false;
                    return resposta;
                }

                resposta.Dados = movimentos;
                resposta.Mensagem = "Lista de movimentações recuperada com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Erro ao listar movimentações: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }

    }
}

