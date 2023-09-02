using APIBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBiblioteca.DATA
{
    public class DataContext : DbContext
    {
        public DbSet<Leitor> Leitores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Locacao>()
                .HasOne(lo => lo.Livro)
                .WithMany()
                .HasForeignKey(lo => lo.LivroId);

            modelBuilder.Entity<Locacao>()
                .HasOne(lo => lo.Leitor)
                .WithMany()
                .HasForeignKey(lo => lo.LeitorId);

            //modelBuilder.Entity<Leitor>()
            //    .HasIndex(leitor => leitor.CPF)
            //    .IsUnique();
        }
    }
}
