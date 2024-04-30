using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class DoctoresModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Especialidad { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? DNI { get; set; }

    }
}
