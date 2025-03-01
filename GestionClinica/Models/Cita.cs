using System.ComponentModel.DataAnnotations;

namespace GestionClinica.Models
{
    public class Cita
    {
        [Key]
        public int Id_Citas { get; set; }


        [Required(ErrorMessage = "La cedula es obligatoria")]
        public int Id_Paciente { get; set; }


        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Id_Medico { get; set; }


        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateOnly Fecha { get; set; }


        [Required(ErrorMessage = "La hora de incio es obligatoria")]
        public TimeOnly HoraInicio { get; set; }


        [Required(ErrorMessage = "La hora del fin de cita es obligatoria")]
        public TimeOnly HoraFinal { get; set; }
    }
}
