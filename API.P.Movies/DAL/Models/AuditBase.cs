using System.ComponentModel.DataAnnotations;

namespace API.P.Movies.DAL.Models
{
    public class AuditBase
    {
        [Key] //Este decorador indica que esta propiedad es la PK
        public virtual int Id { get; set; } //PK

        public virtual DateTime CreatedDate { get; set; } //Indica la fecha de creación de cada registro en BD

        public virtual DateTime? UpdatedDate { get; set; } //Indica la fecha de actualización de cada registro en BD

    }
}
