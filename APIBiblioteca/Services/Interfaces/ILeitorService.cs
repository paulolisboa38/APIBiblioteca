using APIBiblioteca.DTOs;
using APIBiblioteca.Models;

namespace APIBiblioteca.Services.Interfaces
{
    public interface ILeitorService
    {
        // create
        Task<Leitor> CreateLeitorAsync(CreateLeitorDTO leitorDTO);

        // read
        Task<List<Leitor>> GetAllLeitoresAsync();
        Task<Leitor> GetLeitoresByIdAsync(int id);

        // update
        Task<Leitor> UpdateLeitorByIdAsync(int id,UpdateLeitorDTO updateLeitor);

        // delete
        Task<Leitor> DeleteLeitorByIdAsync(int id);
    }
}
