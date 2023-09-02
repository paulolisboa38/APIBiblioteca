using Microsoft.AspNetCore.Mvc;
using APIBiblioteca.Models;
using APIBiblioteca.Services.Interfaces;
using APIBiblioteca.DTOs;

namespace APIBiblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocacoesController : ControllerBase
    {
        private readonly ILocacaoService _locacaoService;

        public LocacoesController(ILocacaoService locacaoService)
        {
            _locacaoService = locacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocacao([FromBody] CreateLocacaoDTO locacaoDTO)
        {
            return Ok(await _locacaoService.CreateLocacaoAsync(locacaoDTO));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocacoes()
        {
            return Ok(await _locacaoService.GetAllLocacoesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocacoesById(int id)
        {
            var locacao = await _locacaoService.GetLocacoesByIdAsync(id);
            if (locacao == null) return NotFound();
            return Ok(locacao);
        }

        [HttpGet("Livro/{livroId}")]
        public async Task<IActionResult> GetLocacoesByLivroId(int livroId)
        {
            var locacoes = await _locacaoService.GetLocacoesByLivroIdAsync(livroId);
            if (locacoes == null || !locacoes.Any())
            {
                return NotFound($"Nenhuma locação encontrada para o livro com Id-{livroId}.");
            }
            return Ok(locacoes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocacao(int id,[FromBody] UpdateLocacaoDTO locacao)
        {
            var updatedLocacao = await _locacaoService.UpdateLocacaoByIdAsync(id,locacao);
            if (updatedLocacao == null)
            {
                return BadRequest($"Nenhuma locação com o Id-{id} encontrada para ser atualizada.");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocacao(int id)
        {
            var locacao = await _locacaoService.DeleteLocacaoByIdAsync(id);
            if (locacao == null) return NotFound();
            return NoContent();
        }
    }

}
