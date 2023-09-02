using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.DTOs
{
    public class CreateLivroDTO
    {
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        [StringLength(255,ErrorMessage = "O campo Título deve ter no máximo 255 caracteres")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Autor é obrigatório")]
        [StringLength(100,ErrorMessage = "O campo Autor deve ter no máximo 100 caracteres")]
        public string Autor { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo Editora é obrigatório")]
        [StringLength(100,ErrorMessage = "O campo Editora deve ter no máximo 100 caracteres")]
        public string Editora { get; set; } = string.Empty;
    }
}
