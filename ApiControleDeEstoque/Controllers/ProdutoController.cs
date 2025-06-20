using ApiControleDeEstoque.Dto.ProdutoDto;
using ApiControleDeEstoque.Models;
using ControleDeEstoqueApi.Services.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }



        [HttpGet("ListaProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListaDeProduto()
        {
            var produto = await _produtoService.ListarProduto();
            return Ok(produto);
        }

        [HttpGet("ProdutoPorId{id:int}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> ProdutoPorId(int id)
        {
            var produto = await _produtoService.ProdutoPorId(id);
            return Ok(produto);

        }
        [HttpPut("EditarProduto)")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> EditarProduto(EdicaoProdutoDto edicaoProdutoDto)
        {
            var produto = await _produtoService.EditarProduto(edicaoProdutoDto);
            return Ok(produto);
        }
        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> CriarProduto(CriacaoProdutoDto criacaoProdutoDto)
        {
            var produto = await _produtoService.CriarProduto(criacaoProdutoDto);
            return Ok(produto);
        }
        [HttpDelete("DeletarProduto{id:int}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> DeletarProduto(int id)
        {
            var produto = await _produtoService.DeletarProduto(id);
            return Ok(produto);
        }

    }
}
