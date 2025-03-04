using Microsoft.AspNetCore.Mvc;

namespace GestionClinica.Controllers
{
    public class PacientesController : Controller
    {
        //aun no he creado este repository por eso lo comento...
        //private PacienteRepository<Paciente> _pacienteRepository;
        //public PacientesController(PacienteRepository<Paciente> pacienteRepository){

        //    _pacienteRepository = pacienteRepository;
        //} 

        public IActionResult Index()
        {
            return View();
        }
    }
}
