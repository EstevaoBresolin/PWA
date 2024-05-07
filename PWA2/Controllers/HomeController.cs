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

        public IActionResult Index()
        {
            var gastosGenericos = Db.ObterGastos();


            ViewBag.Total = GastoTotal(gastosGenericos);
            ViewBag.Saldo = Saldo();
            ViewBag.Outros = Db.Outros().Sum(g => g.Valor);
            ViewBag.Educacao = Db.Educacao().Sum(g => g.Valor);
            ViewBag.Casa = Db.Casa().Sum(g => g.Valor);
            ViewBag.Saude = Db.Saude().Sum(g => g.Valor);
            ViewBag.Lazer = Db.Lazer().Sum(g => g.Valor);
            ViewBag.Alimentacao = Db.Alimentacao().Sum(g => g.Valor);
            ViewBag.Investimentos = Db.Investimentos().Sum(g => g.Valor);


            return View(gastosGenericos);
        }
       


        //////////// OBTER VALORES /////////////////    
        public double Saldo ()
        {
            double saldo = 2000 - Total;
            return saldo;
        }

        public double GastoTotal(List<GastosGenericos> gastos)
        {
            Total = gastos.Sum(x => x.Valor);
            return Total;
        }

        //////////// OBTER VALORES /////////////////
       


        //////////// Adicionar Usuarios ///////////////
        public IActionResult AdicionarGasto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdicionarGasto(GastosGenericos _gastosGenericos)
        {
            string categoria = _gastosGenericos.Categoria;
            switch (categoria)
            {
                case "Educacao":
                    Db.Educacao(_gastosGenericos);
                    break;

                case "Casa":
                    Db.Casa(_gastosGenericos);
                    break;

                case "Saude":
                    Db.Saude(_gastosGenericos);
                    break;

                case "Lazer":
                    Db.Lazer(_gastosGenericos);
                    break;

                case "Alimentacao":
                    Db.Alimentacao(_gastosGenericos);
                    break;

                case "Investimentos":
                    Db.Investimentos(_gastosGenericos);
                    break;

                case "Outros":
                    Db.Outros(_gastosGenericos);
                    break;
            }
            Console.WriteLine(_gastosGenericos.Categoria);
            Db.Geral(_gastosGenericos);
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
                    Console.WriteLine($"O Usu�rio {gastosGenericos.Nome} foi removido com sucesso");
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
        

        
        public IActionResult Excluir(int id)
        {
            Db.Excluir(id);
            return RedirectToAction("Index", "Home");
        }
   
    }
}
