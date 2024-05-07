using Microsoft.AspNetCore.Mvc;
using PWA2.Models;
using System.Diagnostics;
using System.Numerics;

namespace PWA2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        double Total {  get; set; }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public double GastoTotal (List<GastosGenericos> gastos)
        {
            Total = gastos.Sum(x => x.Valor);
            return Total;
        }

        public double Saldo ()
        {
            double saldo = 2000 - Total;
            return saldo;
        }

        public IActionResult Index()
        {
            var gastosGenericos = Db.ObterGastos();
           
            ViewBag.Total = GastoTotal(gastosGenericos);
            ViewBag.Saldo = Saldo();
            return View(gastosGenericos);
        }

        //////////// Adicionar Usuarios ///////////////
        public IActionResult AdicionarGasto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarGasto(GastosGenericos _gastosGenericos)
        {
            Db.AdicionarGasto(_gastosGenericos);
            return RedirectToAction("Index", "Home");
        }

        //////////// Adicionar Usuarios ///////////////

        //////////// Editar Usuarios ///////////////

        public IActionResult Editar(int id)
        {        
             var gastos = Db.ObterGastosPorId(id);

             return View(gastos); 
        }

        [HttpPost]
        public IActionResult Editar(GastosGenericos gastosGenericos)
        {

            if (ModelState.IsValid && gastosGenericos.Id != 1)
            {
                try
                {
                    Console.WriteLine($"O Usuário {gastosGenericos.Nome} foi removido com sucesso");
                    Db.Editar(gastosGenericos);
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error", "Home");
                }
            }

            return View(gastosGenericos);
        }

        //////////// Editar Usuarios ///////////////

        //////////// Login ///////////////
       
        public IActionResult Excluir(int id)
        {
            Db.Excluir(id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            return View();
        }

        //public IActionResult Login(string nome, string senha)
        //{
        //    List<Usuario> usuarios = Db.ObterUsuarios();

        //    Usuario usuarioAutenticado = usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);

        //    if (usuarioAutenticado != null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.MensagemErro = "Usuário ou senha inválidos";
        //        return RedirectToAction("Login", "Home");
        //    }
        //}

        //////////// Login ///////////////

        //////////// Excluir ///////////////

        //public IActionResult Excluir(int id)
        //{
        //    Console.WriteLine(Db.Excluir(id));
        //    return RedirectToAction("Index");
        //}

        //////////// Excluir ///////////////

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

  
    }
}
