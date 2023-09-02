using APIBiblioteca.DTOs;
using APIBiblioteca.Models;
using APIBiblioteca.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        // POST api/<LivrosController>
        [HttpPost]
        public async Task<IActionResult> CreateLivro([FromBody] CreateLivroDTO livro)
        {
            var livroCriado = await _livroService.CreateLivroAsync(livro);
            return Ok(livroCriado);
        }

        // GET: api/<LivrosController>
        [HttpGet]
        public async Task<IActionResult> GetAllLivros()
        {
            var livros = await _livroService.GetAllLivrosAsync();
            return Ok(livros);
        }

        // GET api/<LivrosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLivroById(int id)
        {
            var livro = await _livroService.GetLivroByIdAsync(id);
            if (livro == null)
            {
                return NotFound($"Nenhum livro com o ID-{id} foi encontrado.");
            }
            return Ok(livro);
        }

        // PUT api/<LivrosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] UpdateLivroDTO livroAtualizado)
        {
            var livro = await _livroService.UpdateLivroByIdAsync(id,livroAtualizado);
            if (livro == null)
            {
                return NotFound($"Nenhum livro com o Id-{id} encontrado para ser atualizado.");
            }
            return Ok(livro);
        }

        // DELETE api/<LivrosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livroRemovido = await _livroService.DeleteLivroByIdAsync(id);
            if (livroRemovido == null)
            {
                return NotFound($"Nenhum livro com o Id-{id} encontrado para ser removido.");
            }
            return Ok(livroRemovido);
        }
    }
}
