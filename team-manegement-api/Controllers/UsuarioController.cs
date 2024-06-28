using Microsoft.AspNetCore.Mvc;

namespace team_manegement_api.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
