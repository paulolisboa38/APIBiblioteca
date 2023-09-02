using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.DTOs
{
    public class UpdateLeitorDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(100,ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Range(0,120,ErrorMessage = "Idade deve estar entre 0 e 120")]
        public int Idade { get; set; } = 0;
    }
}
