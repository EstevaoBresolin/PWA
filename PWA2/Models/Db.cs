//using Microsoft.VisualBasic;

//namespace PWA2.Models
//{
//    public class Db
//    {
//        //////////////// LISTAS DE CATEGORIAS /////////////////////

//        private static List<GastosGenericos> geral = new List<GastosGenericos>();
//        private static List<GastosGenericos> outros = new List<GastosGenericos>();
//        private static List<GastosGenericos> educacao = new List<GastosGenericos>();
//        private static List<GastosGenericos> casa = new List<GastosGenericos>();
//        private static List<GastosGenericos> saude = new List<GastosGenericos>();
//        private static List<GastosGenericos> lazer = new List<GastosGenericos>();
//        private static List<GastosGenericos> alimentacao = new List<GastosGenericos>();
//        private static List<GastosGenericos> investimentos = new List<GastosGenericos>();
//        private static List<GastosGenericos> transporte = new List<GastosGenericos>();
//        private static double orcamento = new double();


//        private static int proximoId = 1;


//        //////////////// LISTAS DE CATEGORIAS /////////////////////




//        /////////////// ADICIONAR CATEGORIAS /////////////////
//        public static bool Geral(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            geral.Add(_gastosGenericos);

//            return true;
//        }
//        public static bool Outros(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            outros.Add(_gastosGenericos);

//            return true;
//        }

//        public static void Educacao(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            educacao.Add(_gastosGenericos);          
//        }

//        public static void Casa(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            casa.Add(_gastosGenericos);
//        }

//        public static void Saude(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            saude.Add(_gastosGenericos);
//        }

//        public static void Lazer(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            lazer.Add(_gastosGenericos);
//        }

//        public static void Alimentacao(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            alimentacao.Add(_gastosGenericos);
//        }

//        public static void Investimentos(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            investimentos.Add(_gastosGenericos);
//        }
//        public static void Transporte(GastosGenericos _gastosGenericos)
//        {
//            _gastosGenericos.Id = proximoId++;
//            Console.WriteLine($"Usuario {_gastosGenericos.Nome} foi adicionado com sucesso");
//            transporte.Add(_gastosGenericos);
//        }

//        public static void Orcamento(double _orcamento)
//        {
//            orcamento = _orcamento;
//        }

//        /////////////// ADICIONAR CATEGORIAS /////////////////



//        /////////// RETORNAR CATEGORIAS ///////////

//        public static List<GastosGenericos> Outros() { return outros; }
//        public static List<GastosGenericos> Educacao() { return educacao; }
//        public static List<GastosGenericos> Casa() { return casa; }
//        public static List<GastosGenericos> Saude() { return saude; }
//        public static List<GastosGenericos> Alimentacao() { return alimentacao; }
//        public static List<GastosGenericos> Investimentos() { return investimentos; }
//        public static List<GastosGenericos> Lazer() { return lazer; }
//        public static List<GastosGenericos> Transporte() { return transporte; }

//        public static List<GastosGenericos> Geral() { return geral; }


//        /////////// RETORNAR CATEGORIAS ///////////

//        public static GastosGenericos ObterGastosPorId(int id)
//        {

//            foreach (var gasto in geral)
//            {
//                if (gasto.Id == id)
//                {
//                    return gasto;
//                }
//            }
//            return null;
//        }

//        public static string Excluir(int id)
//        {
//            geral.RemoveAll(u => u.Id == id);
//            outros.RemoveAll(u => u.Id == id);
//            educacao.RemoveAll(u => u.Id == id);
//            casa.RemoveAll(u => u.Id == id);
//            saude.RemoveAll(u => u.Id == id);
//            alimentacao.RemoveAll(u => u.Id == id);
//            investimentos.RemoveAll(u => u.Id == id);
//            lazer.RemoveAll(u => u.Id == id);
//            transporte.RemoveAll(u => u.Id == id);
//            return $"Usuario {id} foi removido com sucesso";
//        }

//        public static List<GastosGenericos> ObterGastos() { return geral; }

//        public static double ObterOrcamento() { return orcamento; }

//        public static void Editar(GastosGenericos _gastosGenericos)
//        {
//            Console.WriteLine($"Gastos com  {_gastosGenericos.Nome} foi editado com sucesso");        

//            var gastoExistente = geral.FirstOrDefault(u => u.Id == _gastosGenericos.Id);
//            if (gastoExistente != null)
//            {
//                gastoExistente.Nome = _gastosGenericos.Nome;
//                gastoExistente.Valor = _gastosGenericos.Valor;
//                gastoExistente.Categoria = _gastosGenericos.Categoria;
//                gastoExistente.Data = _gastosGenericos.Data;
//            }
//        }

//    }
//}

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using GerenciadorFinancas.Models;

namespace PWA2.Models
{
    public class Db
    {
        private readonly MyDbContext _context;

        public Db(MyDbContext context)
        {
            _context = context;
        }

        // Adicionar categorias
        public bool AdicionarGasto(GastosGenericos gasto)
        {
            _context.GastosGenericos.Add(gasto);
            _context.SaveChanges();
            return true;
        }

        // Obter categorias
        public List<GastosGenericos> ObterGastosPorCategoria(string categoria)
        {
            return _context.GastosGenericos.Where(g => g.Categoria == categoria).ToList();
        }

        // Obter todos os gastos
        public List<GastosGenericos> ObterTodosGastos()
        {
            return _context.GastosGenericos.ToList();
        }

        // Obter gasto por ID
        public GastosGenericos ObterGastoPorId(int id)
        {
            return _context.GastosGenericos.Find(id);
        }

        // Excluir gasto
        public string ExcluirGasto(int id)
        {
            var gasto = _context.GastosGenericos.Find(id);
            if (gasto != null)
            {
                _context.GastosGenericos.Remove(gasto);
                _context.SaveChanges();
                return $"Gasto {id} foi removido com sucesso";
            }
            return $"Gasto {id} não encontrado";
        }

        // Editar gasto
        public void EditarGasto(GastosGenericos gasto)
        {
            _context.GastosGenericos.Update(gasto);
            _context.SaveChanges();
        }
    }
}
