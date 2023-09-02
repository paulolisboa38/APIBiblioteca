using APIBiblioteca.DATA;
using APIBiblioteca.DTOs;
using APIBiblioteca.Models;
using APIBiblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Services
{
    public class LivroService : ILivroService
    {
        private readonly DataContext _dataContext;

        public LivroService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Livro> CreateLivroAsync(CreateLivroDTO livro)
        {
            var livroCriado = new Livro
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Editora = livro.Editora
            };
            await _dataContext.Livros.AddAsync(livroCriado);
            await _dataContext.SaveChangesAsync();
            return livroCriado;
        }

        public async Task<List<Livro>> GetAllLivrosAsync()
        {
            return await _dataContext.Livros.ToListAsync();
        }

        public async Task<Livro> GetLivroByIdAsync(int id)
        {
            var livro = await _dataContext.Livros.FindAsync(id);
            return livro;
        }

        public async Task<Livro> UpdateLivroByIdAsync(int id,UpdateLivroDTO livroAtualizado)
        {
            var livro = await _dataContext.Livros.FindAsync(id);
            if (livro == null)
            {
                return null;
            }
            livro.Titulo = livroAtualizado.Titulo;
            livro.Editora = livroAtualizado.Editora;
            await _dataContext.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro> DeleteLivroByIdAsync(int id)
        {
            var livro = await _dataContext.Livros.FindAsync(id);
            if (livro == null)
            {
                return null;
            }
            _dataContext.Livros.Remove(livro);
            await _dataContext.SaveChangesAsync();
            return livro;
        }
    }
}
