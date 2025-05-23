﻿using System.ComponentModel.DataAnnotations;

namespace GestionClinica.Models
{
    public class Especialidad
    {

        [Key]
        public int Id_Especialidad { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
    }
}
