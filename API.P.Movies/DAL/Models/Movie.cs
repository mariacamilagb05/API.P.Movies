using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [Display(Name = "Película")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Duración de la película")]
        public int Duration { get; set; }

        [Display(Name = "Duración de la película")]
        public String? Description { get; set; }

        [Required]
        [Display(Name = "Duración de la película")]
        public String Clasification { get; set; }
    }
}
