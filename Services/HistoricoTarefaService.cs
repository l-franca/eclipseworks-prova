using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using eclipseworks_teste.ViewModel;

namespace eclipseworks_teste.Services
{
    public interface IHistoricoTarefaService
    {
        IList<HistoricoTarefa> GetAllComentarios(long usuarioId, long tarefaId);
        IList<HistoricoTarefa> GetAllUpdates(long usuarioId, long tarefaId);
        IList<HistoricoTarefa> ObterTodos();
    }

    public class HistoricoTarefaService : IHistoricoTarefaService
    {
        private readonly IHistoricoTarefaRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        public HistoricoTarefaService(IHistoricoTarefaRepository historicoTarefaRepository, IUsuarioRepository usuarioRepository)
        {
            _repository = historicoTarefaRepository;
            _usuarioRepository = usuarioRepository;
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