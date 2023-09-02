using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.DTOs
{
    public class UpdateLocacaoDTO
    {
        [Required(ErrorMessage = "O campo LeitorId é obrigatório")]
        public int LeitorId { get; set; }

        [Required(ErrorMessage = "O campo LivroId é obrigatório")]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "A Data de Devolução é obrigatória")]
        public DateTime DataDevolucao { get; set; } = DateTime.Now;
    }
}
