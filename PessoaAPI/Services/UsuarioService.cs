using PessoaAPI.Models;
using PessoaAPI.Repository;

namespace PessoaAPI.Services;

public class UsuarioService
{
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioService()
    {
    }

    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    public Usuario GetUsuario(string nomeUsuario, string senhaUsuario)
    {
        return _usuarioRepository.Get(nomeUsuario, senhaUsuario);
    }
}
