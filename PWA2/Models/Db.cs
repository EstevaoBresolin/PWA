using Microsoft.VisualBasic;

namespace PWA2.Models
{
    public class Db
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public static bool AdicionarUsuario(Usuario usuario)
        {
            Console.WriteLine($"Usuario {usuario.Nome} foi adicionado com sucesso");
            usuarios.Add(usuario);
            return true;
        }

        public static string Excluir(int Id)
        {
            if(Id != 1)
            {
                usuarios.RemoveAll(u => u.Id == Id);
                return $"Usuario {Id} foi removido com sucesso";
            }
            else
            {
                return "O Administrador não pode ser removido";
            }                  
        }

        public static List<Usuario> ObterUsuarios() { return usuarios; }

        public static Usuario ObterUsuarioPorId(int id)
        {
            Usuario user = new Usuario();
            foreach (var usuario in usuarios)
            {
                if(usuario.Id == id)
                {
                    user = usuario;
                }
            }
            return user;
        }

        public static void Editar(Usuario usuario)
        {
            Console.WriteLine($"O usuario {usuario.Nome} foi editado com sucesso");
            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (usuarioExistente != null)
            {
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Idade = usuario.Idade;
                usuarioExistente.Celular = usuario.Celular;
            }
        }
    }
}
