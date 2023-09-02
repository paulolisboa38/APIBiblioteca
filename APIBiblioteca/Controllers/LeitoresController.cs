using APIBiblioteca.DTOs;
using APIBiblioteca.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeitoresController : ControllerBase
    {
        private readonly ILeitorService _leitorService;

        public LeitoresController(ILeitorService leitorService)
        {
            _leitorService = leitorService;
        }

        // POST api/<LeitoresController>
        [HttpPost]
        public async Task<IActionResult> CreateLeitor(CreateLeitorDTO leitorDTO)
        {
            if (leitorDTO == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var leitorCriado = await _leitorService.CreateLeitorAsync(leitorDTO);
            return Ok(leitorCriado);
            //var leitorCriado = await _leitorService.CreateLeitorAsync(leitorDTO);
            //return CreatedAtAction(nameof(GetAllLeitores),new { id = leitorCriado.Id },leitorCriado);
        }

        // GET: api/<LeitoresController>
        [HttpGet]
        public async Task<IActionResult> GetAllLeitores()
        {
            var leitores = await _leitorService.GetAllLeitoresAsync();
            if (!leitores.Any())
            {
                return NotFound("Nenhum leitor encontrado.");
            }
            return Ok(leitores);
        }

        // GET: api/<LeitoresController>5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeitoresById(int id)
        {
            var leitor = await _leitorService.GetLeitoresByIdAsync(id);
            if (leitor == null)
            {
                return NotFound($"Nenhum leitor com o id-{id} encontrado.");
            }
            return Ok(leitor);
        }

        // PUT api/<LeitoresController>
        [HttpPut]
        public async Task<IActionResult> UpdateLeitorById(int id,UpdateLeitorDTO updateLeitor)
        {
            var leitorAtualizado = await _leitorService.UpdateLeitorByIdAsync(id,updateLeitor);
            if (leitorAtualizado == null || !ModelState.IsValid)
            {
                return NotFound($"Nenhum leitor com o Id-{id} encontrado para ser atualizado.");
            }
            return Ok(leitorAtualizado);
        }

        // DELETE api/<LeitoresController>
        [HttpDelete]
        public async Task<IActionResult> DeleteLeitorById(int id)
        {
            var leitorRemovido = await _leitorService.DeleteLeitorByIdAsync(id);
            if (leitorRemovido == null)
            {
                return NotFound($"Nenhum leitor com o Id-{id} encontrado para ser removido.");
            }
            return Ok($"Leitor com o Id-{id} removido com sucesso.");
        }
    }
}
