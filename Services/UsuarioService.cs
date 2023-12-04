using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;

namespace eclipseworks_teste.Services
{
    public interface IUsuarioService
    {
        Usuario AddUsuario(Usuario usuario);
        bool CheckIfGerente(long usuarioId);
        IList<Usuario> ObterTodos();
    }

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public IList<Usuario> ObterTodos() { return _repository.GetAll(); }
        public bool CheckIfGerente(long usuarioId) { return _repository.CheckIfGerente(usuarioId); }

        public Usuario AddUsuario(Usuario usuario) { _repository.Save(usuario); return usuario; }
    }
}