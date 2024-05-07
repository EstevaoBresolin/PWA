using Microsoft.VisualBasic;

namespace PWA2.Models
{
    public class Db
    {
        //////////////// LISTAS DE CATEGORIAS /////////////////////
        
        private static List<GastosGenericos> geral = new List<GastosGenericos>();
        private static List<GastosGenericos> outros = new List<GastosGenericos>();
        private static List<GastosGenericos> educacao = new List<GastosGenericos>();
        private static List<GastosGenericos> casa = new List<GastosGenericos>();
        private static List<GastosGenericos> saude = new List<GastosGenericos>();
        private static List<GastosGenericos> lazer = new List<GastosGenericos>();
        private static List<GastosGenericos> alimentacao = new List<GastosGenericos>();
        private static List<GastosGenericos> investimentos = new List<GastosGenericos>();
        private static List<GastosGenericos> transporte = new List<GastosGenericos>();

        //////////////// LISTAS DE CATEGORIAS /////////////////////
 


        /////////////// ADICIONAR CATEGORIAS /////////////////
        public static bool Geral(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            geral.Add(_gastosGenericos);

            return true;
        }
        public static bool Outros(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            outros.Add(_gastosGenericos);
            
            return true;
        }

        public static void Educacao(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            educacao.Add(_gastosGenericos);          
        }

        public static void Casa(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            casa.Add(_gastosGenericos);
        }

        public static void Saude(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            saude.Add(_gastosGenericos);
        }

        public static void Lazer(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            lazer.Add(_gastosGenericos);
        }

        public static void Alimentacao(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            alimentacao.Add(_gastosGenericos);
        }

        public static void Investimentos(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            investimentos.Add(_gastosGenericos);
        }
        public static void Transporte(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            transporte.Add(_gastosGenericos);
        }

        /////////////// ADICIONAR CATEGORIAS /////////////////
      


        /////////// RETORNAR CATEGORIAS ///////////
        
        public static List<GastosGenericos> Outros() { return outros; }
        public static List<GastosGenericos> Educacao() { return educacao; }
        public static List<GastosGenericos> Casa() { return casa; }
        public static List<GastosGenericos> Saude() { return saude; }
        public static List<GastosGenericos> Alimentacao() { return alimentacao; }
        public static List<GastosGenericos> Investimentos() { return investimentos; }
        public static List<GastosGenericos> Lazer() { return lazer; }
        public static List<GastosGenericos> Transporte() { return transporte; }

        /////////// RETORNAR CATEGORIAS ///////////

        public static GastosGenericos ObterGastosPorId(int id)
        {
           
            foreach (var gasto in geral)
            {
                if (gasto.Id == id)
                {
                    return gasto;
                }
            }
            return null;
        }

        public static string Excluir(int id)
        {
            geral.RemoveAll(u => u.Id == id);
            return $"Usuario {id} foi removido com sucesso";
        }

        public static List<GastosGenericos> ObterGastos() { return geral; }

        public static void Editar(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Gastos com  {_gastosGenericos.Nome} foi editado com sucesso");        

            var gastoExistente = geral.FirstOrDefault(u => u.Id == _gastosGenericos.Id);
            if (gastoExistente != null)
            {
                gastoExistente.Nome = _gastosGenericos.Nome;
                gastoExistente.Valor = _gastosGenericos.Valor;
                gastoExistente.Categoria = _gastosGenericos.Categoria;
            }
        }
    }
}
