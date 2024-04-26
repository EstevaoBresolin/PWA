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
        public IActionResult Login(string nome, string senha)
        {
            List<Usuario> usuarios = Db.ObterUsuarios();
            
            Usuario usuarioAutenticado = usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);

            if (usuarioAutenticado != null)
            {        
                return RedirectToAction("Index", "Home");
            }
            else
            {             
                ViewBag.MensagemErro = "Usuário ou senha inválidos";
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Editar(int id)
        {
            var usuario = Db.ObterUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult Editar(Usuario usuario)
        {   

            if(ModelState.IsValid && usuario.Id != 1)
            {
                try
                {
                    Console.WriteLine($"O Usuário {usuario.Nome} foi removido com sucesso");
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
        [HttpPost]
        public IActionResult Compras(int n1, int n2) { 
            int n3 = n1 + n2;
            Console.WriteLine(n3);
            return RedirectToAction("Index", "Home");
        }


        
    }
}
