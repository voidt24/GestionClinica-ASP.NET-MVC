using Microsoft.AspNetCore.Mvc;

namespace GestionClinica.Controllers
{
    public class MedicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
