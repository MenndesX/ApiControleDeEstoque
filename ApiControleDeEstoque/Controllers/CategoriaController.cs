using ApiControleDeEstoque.Dto.CategoriaDto;
using ApiControleDeEstoque.Models;
using ApiControleDeEstoque.Services.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("ListaCategoria")]
        public async Task<ActionResult<ResponseModel<List<CategoriaModel>>>> ListaCategoria()
        {
            var listaDeCategoria = await _categoriaService.ListarCategoria();
            return Ok(listaDeCategoria);
        }
        [HttpGet("{id:int}CategoriaPorId")]
        public async Task<ActionResult<ResponseModel<CategoriaModel>>> CategoriaPorId(int id)
        {
            var categoriaPorId = await _categoriaService.ListarCategoriaPorId(id);
            return Ok(categoriaPorId);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CriaCategoria")]
        public async Task<ActionResult<ResponseModel<CategoriaModel>>> CriarCategoria(CriacaoCategoriaDto criacaoCategoriaDto)
        {
            var criarCategoria = await _categoriaService.CriarCategoria(criacaoCategoriaDto);
            return Ok(criarCategoria);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("EditarCategoria")]
        public async Task<ActionResult<ResponseModel<CategoriaModel>>> EditarCategoria(EdicaoCategoriaDto edicaoCategoriaDto)
        {
            var editarCategoria = await _categoriaService.EditarCategoria(edicaoCategoriaDto);
            return Ok(editarCategoria);

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeletarCategoria{id:int}")]
        public async Task<ActionResult<ResponseModel<CategoriaModel>>> DeletarCategoria(int id)
        {
            var deletarCategoria = await _categoriaService.DeletarCategoria(id);
            return Ok(deletarCategoria);
        }

    }
}
