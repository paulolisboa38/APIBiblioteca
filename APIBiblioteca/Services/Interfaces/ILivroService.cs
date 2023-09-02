using APIBiblioteca.DTOs;
using APIBiblioteca.Models;

namespace APIBiblioteca.Services.Interfaces
{
    public interface ILivroService
    {
        // create
        Task<Livro> CreateLivroAsync(CreateLivroDTO livro);
        Task<Livro> GetLivroByIdAsync(int id);

        // read
        Task<List<Livro>> GetAllLivrosAsync();

        // update
        Task<Livro> UpdateLivroByIdAsync(int id,UpdateLivroDTO livroAtualizado);

        // delete
        Task<Livro> DeleteLivroByIdAsync(int id);
    }
}
