using APIBiblioteca.DATA;
using APIBiblioteca.DTOs;
using APIBiblioteca.Models;
using APIBiblioteca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.Services
{
    public class LocacaoService : ILocacaoService
    {
        private readonly DataContext _dataContext;

        public LocacaoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Locacao> CreateLocacaoAsync(CreateLocacaoDTO locacaoDTO)
        {
            var leitor = await _dataContext.Leitores.FindAsync(locacaoDTO.LeitorId);
            var livro = await _dataContext.Livros.FindAsync(locacaoDTO.LivroId);
            if (leitor == null || livro == null)
            {
                return null;
            }
            var novaLocacao = new Locacao
            {
                LeitorId = locacaoDTO.LeitorId,
                Leitor = leitor,
                LivroId = locacaoDTO.LivroId,
                Livro = livro,
                DataLocacao = locacaoDTO.DataLocacao,
                DataDevolucao = locacaoDTO.DataDevolucao
            };
            await _dataContext.Locacoes.AddAsync(novaLocacao);
            await _dataContext.SaveChangesAsync();
            return novaLocacao;
        }

        public async Task<IEnumerable<Locacao>> GetAllLocacoesAsync()
        {
            return await _dataContext.Locacoes
                 .Include(l => l.Livro)
                 .Include(l => l.Leitor)
                 .ToListAsync();
        }

        public async Task<Locacao> GetLocacoesByIdAsync(int id)
        {
            return await _dataContext.Locacoes
                 .Include(l => l.Livro)
                 .Include(l => l.Leitor)
                 .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Locacao>> GetLocacoesByLivroIdAsync(int livroId)
        {
            return await _dataContext.Locacoes
                 .Where(locacao => locacao.LivroId == livroId)
                 .Include(locacao => locacao.Leitor)
                 .Include(locacao => locacao.Livro)
                 .ToListAsync();
        }

        public async Task<Locacao> UpdateLocacaoByIdAsync(int id,UpdateLocacaoDTO locacao)
        {
            var locacaoDb = await _dataContext.Locacoes.FindAsync(id);
            if (locacaoDb == null)
            {
                return null;
            }
            locacaoDb.LeitorId = locacao.LeitorId;
            locacaoDb.LivroId = locacao.LivroId;
            locacaoDb.DataDevolucao = locacao.DataDevolucao;
            await _dataContext.SaveChangesAsync();
            return locacaoDb;
        }

        public async Task<Locacao> DeleteLocacaoByIdAsync(int id)
        {
            var locacao = await _dataContext.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return null;
            }
            _dataContext.Locacoes.Remove(locacao);
            await _dataContext.SaveChangesAsync();
            return locacao;
        }
    }
}
