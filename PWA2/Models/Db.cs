namespace PWA2.Models
{
    public class Db
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        public static bool AdicionarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
            return true;
        }
        
        public static List<Usuario> ObterUsuarios() { return usuarios; }
    }
}
