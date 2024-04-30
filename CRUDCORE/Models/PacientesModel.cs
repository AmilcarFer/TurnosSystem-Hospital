using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class PacientesModel
    {
        public int IdContacto { get; set; }

        [Required(ErrorMessage ="El campo es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Telefono { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Apellido { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ObraSocial { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? DNI { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Area { get; set; }

    }
}
