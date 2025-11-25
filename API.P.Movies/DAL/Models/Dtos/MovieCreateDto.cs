using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models.Dtos
{
    public class MovieCreateDto
    {
        [Required(ErrorMessage = "El nombre de la película es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración de la película es obligatoria.")]
        [Range(1, 500, ErrorMessage = "La duración debe estar entre 1 y 500 minutos.")]
        public int Duration { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "La clasificación de la película es obligatoria.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Clasification { get; set; }
    }
}
