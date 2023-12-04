using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using eclipseworks_teste.ViewModel;

namespace eclipseworks_teste.Services
{
    public class HistoricoTarefaService
    {
        private readonly HistoricoTarefaRepository _repository;
        private readonly UsuarioRepository _usuarioRepository;
        public HistoricoTarefaService(EclipseContext context)
        {
            _repository = new HistoricoTarefaRepository(context);
            _usuarioRepository = new UsuarioRepository(context);
        }

        public IList<HistoricoTarefa> ObterTodos() { return _repository.GetAll(); }
        public IList<HistoricoTarefa> GetAllComentarios(long usuarioId, long tarefaId)
        {
            if (_usuarioRepository.CheckIfGerente(usuarioId))
            {
                return _repository.GetAllComentarios(tarefaId);
            }
            return new List<HistoricoTarefa>();
        }
        public IList<HistoricoTarefa> GetAllUpdates(long usuarioId, long tarefaId)
        {
            if (_usuarioRepository.CheckIfGerente(usuarioId))
            {
                return _repository.GetAllUpdates(tarefaId);
            }
            return new List<HistoricoTarefa>();
        }
    }
}