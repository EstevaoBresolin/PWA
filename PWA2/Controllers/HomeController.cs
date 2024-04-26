using Microsoft.AspNetCore.Mvc;
using PWA2.Models;
using System.Diagnostics;

namespace PWA2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var usuarios = Db.ObterUsuarios();
            return View(usuarios);
        }

        public IActionResult AdicionarUsuario()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            if(id != 1) {
                
                var usuarios = Db.ObterUsuarioPorId(id);
                
                return View(usuarios);
            }
            else
            {   
                Console.WriteLine("O Usuário Administrador não pode ser editado");
                return RedirectToAction("Index");
            }
        }

        public  IActionResult Excluir(int id)
        {
            Console.WriteLine( Db.Excluir(id));
            return RedirectToAction("Index");
        }

        public IActionResult Compras()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    Db.Editar(usuario);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            return View(usuario);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
