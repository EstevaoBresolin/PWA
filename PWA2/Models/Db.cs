using Microsoft.VisualBasic;

namespace PWA2.Models
{
    public class Db
    {
        private static List<GastosGenericos> gastosGenericos = new List<GastosGenericos>();

        public static bool AdicionarGasto(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
            gastosGenericos.Add(_gastosGenericos);
            
            return true;
        }

        public static string Excluir(int id)
        {        
             gastosGenericos.RemoveAll(u => u.Id == id);
             return $"Usuario {id} foi removido com sucesso";                             
        }

        public static List<GastosGenericos> ObterGastos() { return gastosGenericos; }

        public static GastosGenericos ObterGastosPorId(int id)
        {
           
            foreach (var gasto in gastosGenericos)
            {
                if (gasto.Id == id)
                {
                    return gasto;
                }
            }
            return null;
        }



        public static void Editar(GastosGenericos _gastosGenericos)
        {
            Console.WriteLine($"Gastos com  {_gastosGenericos.Nome} foi editado com sucesso");        

            var gastoExistente = gastosGenericos.FirstOrDefault(u => u.Id == _gastosGenericos.Id);
            if (gastoExistente != null)
            {
                gastoExistente.Nome = _gastosGenericos.Nome;
                gastoExistente.Valor = _gastosGenericos.Valor;
            }
        }
    }
}
