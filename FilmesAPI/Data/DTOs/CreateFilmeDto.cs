using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTOs
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range(1, 300, ErrorMessage = "A duração deve ter no minimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }
        
    }
}
