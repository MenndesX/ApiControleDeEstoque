using ApiControleDeEstoque.Dto.MovimentoDto;
using ApiControleDeEstoque.Models;

using ControleDeEstoqueApi.Services.Movimento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoEstoqueController : ControllerBase
    {
        private readonly IMovimentoService _movimentoService;
        public MovimentoEstoqueController(IMovimentoService movimentoService)
        {
            _movimentoService = movimentoService;
        }

        [HttpPost("CriarMovimento")]
        public async Task<ActionResult<ResponseModel<MovimentoEstoqueModel>>> CriarMovimento(CriacaoMovimentoDto dto)
        {
            var movimento = await _movimentoService.CriarMovimento(dto);
            return Ok(movimento);
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ResponseModel<MovimentoEstoqueModel>>> ListarMovimentos()
        {
            var resposta = await _movimentoService.ListarMovimentos();
            return Ok(resposta);
        }


    }
}
