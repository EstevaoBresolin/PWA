using PWA2.Controllers;

namespace PWA2.Models
{
    public class GastosGenericos
    {
        HomeController controller;

        public int Id { get; set; }
        public string Nome { get; set; }

        public double Valor { get; set; }

        public string Categoria { get; set; }


        public GastosGenericos (int id,string Nome, double Valor, string Categoria)
        {
            this.Id = id;
            this.Nome = Nome;
            this.Valor = Valor;
            this.Categoria = Categoria;
        }

        public GastosGenericos()
        {
          
        }

    }
}
