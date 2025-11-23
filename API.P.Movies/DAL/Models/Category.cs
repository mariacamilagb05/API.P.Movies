using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required] //Decorator también se llama Data Annotations
        [Display(Name = "Categoría")] //Este decorador me permite cambiar el nombre de la propiedad en las vistas
        public String Name { get; set; }
    }
}
