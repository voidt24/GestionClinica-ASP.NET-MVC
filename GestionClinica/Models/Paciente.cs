using System.ComponentModel.DataAnnotations;

namespace GestionClinica.Models
{
    public class Paciente
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "La cedula es obligatoria")]
        public int Cedula { get; set; }
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
       
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        public string? Telefono { get; set; }

    }
}
