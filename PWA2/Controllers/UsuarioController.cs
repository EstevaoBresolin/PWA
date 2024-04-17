using Microsoft.AspNetCore.Mvc;
using PWA2.Models;

namespace PWA2.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpPost]
        public IActionResult AdicionarUsuario(Usuario usuario)
        {
            Db.AdicionarUsuario(usuario);
            return RedirectToAction("Index", "Home");
        }

        
    }
}
