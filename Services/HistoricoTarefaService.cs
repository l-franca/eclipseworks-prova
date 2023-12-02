using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;

namespace eclipseworks_teste.Services
{
    public class HistoricoTarefaService
    {
        private readonly HistoricoTarefaRepository _repository;
        public HistoricoTarefaService(EclipseContext context) { 
            _repository = new HistoricoTarefaRepository(context);
        }

        public IList<HistoricoTarefa> ObterTodos() { return _repository.GetAll(); }
    }
}