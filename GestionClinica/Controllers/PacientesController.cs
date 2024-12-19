using Microsoft.AspNetCore.Mvc;

namespace GestionClinica.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
