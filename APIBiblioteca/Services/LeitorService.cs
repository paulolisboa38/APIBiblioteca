using APIBiblioteca.DATA;
using APIBiblioteca.DTOs;
using APIBiblioteca.Models;
using APIBiblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Services
{
    public class LeitorService : ILeitorService
    {
        private readonly DataContext _dataContext;

        public LeitorService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Leitor> CreateLeitorAsync(CreateLeitorDTO leitorDTO)
        {
            var leitorCriado = new Leitor
            {
                Nome = leitorDTO.Nome,
                CPF = leitorDTO.CPF,
                Idade = leitorDTO.Idade
            };
            await _dataContext.Leitores.AddAsync(leitorCriado);
            await _dataContext.SaveChangesAsync();
            return leitorCriado;
        }

        public async Task<List<Leitor>> GetAllLeitoresAsync()
        {
            var leitores = await _dataContext.Leitores.ToListAsync();
            return leitores;
        }

        public async Task<Leitor> GetLeitoresByIdAsync(int id)
        {
            var leitor = await _dataContext.Leitores.FindAsync(id);
            return leitor;
        }

        public async Task<Leitor> UpdateLeitorByIdAsync(int id,UpdateLeitorDTO updateLeitor)
        {
            var leitorDb = await _dataContext.Leitores.FindAsync(id);
            if (leitorDb == null)
            {
                return null;
            }
            leitorDb.Nome = updateLeitor.Nome;
            leitorDb.Idade = updateLeitor.Idade;
            await _dataContext.SaveChangesAsync();
            return leitorDb;
        }

        public async Task<Leitor> DeleteLeitorByIdAsync(int id)
        {
            var leitor = await _dataContext.Leitores.FindAsync(id);
            if (leitor == null)
            {
                return null;
            }
            _dataContext.Remove(leitor);
            await _dataContext.SaveChangesAsync();
            return leitor;
        }
    }
}
