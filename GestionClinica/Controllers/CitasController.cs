using Microsoft.AspNetCore.Mvc;

namespace GestionClinica.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
