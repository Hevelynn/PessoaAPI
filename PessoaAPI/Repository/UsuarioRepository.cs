using PessoaAPI.Models;

namespace PessoaAPI.Repository
{
    public class UsuarioRepository
    {
        public Usuario Get(string nomeUsuario, string senhaUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();

            Usuario usuario1 = new Usuario("admin", "123456");
            usuarios.Add(usuario1);
            Usuario usuario2 = new Usuario("fulano", "654321");
            usuarios.Add(usuario2);

            return usuarios.Where(x => x.NomeUsuario.ToLower() == nomeUsuario.ToLower() && x.Senha == senhaUsuario).FirstOrDefault();
        }

    }
}
