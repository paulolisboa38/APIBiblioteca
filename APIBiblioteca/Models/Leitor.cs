using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Models
{
    public class Leitor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100,ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",ErrorMessage = "O CPF não está no formato correto.")]
        public string CPF { get; set; } = string.Empty;

        [Range(0,120,ErrorMessage = "Idade deve estar entre 0 e 120")]
        public int Idade { get; set; } = 0;
    }
}
