using DAL.DataAccess;
using GestionClinica.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionClinica.Controllers
{
    public class MedicosController : Controller
    {

        private MedicoRepository<Medico> _medicoRepository;
        private EspecialidadRepository<Especialidad> _especialidadRepository;

        public MedicosController(MedicoRepository<Medico> medicosRepository, EspecialidadRepository<Especialidad> especialidadRepository)
        {
            _medicoRepository = medicosRepository;
            _especialidadRepository = especialidadRepository;
        }
        public async Task<IActionResult> Index()
        {
            var especialidades = await _especialidadRepository.GetEspecialidades();

            return View(especialidades);
        } 
        
        public async Task<IActionResult> Listado()
        {
            var listas = await _medicoRepository.GetMedicos();
            return View(listas);
        }


        [HttpPost]
        public async Task<ActionResult> AgregarMedico(Medico medico)
        {
            try
            {
                await _medicoRepository.crearMedico(medico);
                TempData["Message"] = "medico agregado con exito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "error al agregar medico" + ex;
                return RedirectToAction("Index");

            }


        }



        [HttpPost]
        public async Task<ActionResult> AgregarEspecialidadMedico(Especialidad especialidad)
        {
            try
            {
                await _especialidadRepository.AgregarEspecialidad(especialidad);
                TempData["Mensaje"] = "especialidad guardada con éxito!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = "Error al intentar guardar especialidad";
                return RedirectToAction("Index");
            }

        }
    }
}
