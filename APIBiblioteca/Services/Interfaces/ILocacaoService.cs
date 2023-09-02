using APIBiblioteca.DTOs;
using APIBiblioteca.Models;

namespace APIBiblioteca.Services.Interfaces
{
    public interface ILocacaoService
    {
        // create
        Task<Locacao> CreateLocacaoAsync(CreateLocacaoDTO locacao);

        // read
        Task<IEnumerable<Locacao>> GetAllLocacoesAsync();
        Task<Locacao> GetLocacoesByIdAsync(int id);
        Task<List<Locacao>> GetLocacoesByLivroIdAsync(int livroId);

        // update
        Task<Locacao> UpdateLocacaoByIdAsync(int id,UpdateLocacaoDTO locacaoDTO);

        // delete
        Task<Locacao> DeleteLocacaoByIdAsync(int id);
    }
}
