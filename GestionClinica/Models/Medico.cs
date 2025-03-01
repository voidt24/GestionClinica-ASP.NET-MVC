using System.ComponentModel.DataAnnotations;

namespace GestionClinica.Models
{
    public class Medico
    {
        [Key]
        public int Id_Medico { get; set; }


        [Required(ErrorMessage = "La cedula es obligatoria")]
        public string CedulaMedico { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        public int Id_Especialidad { get; set; }
        public string? Tel { get; set; }

    }
}
