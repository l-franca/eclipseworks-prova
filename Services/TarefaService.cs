using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;

namespace eclipseworks_teste.Services
{
    public class TarefaService
    {
        private readonly TarefaRepository _repository;
        public TarefaService(EclipseContext context) { 
            _repository = new TarefaRepository(context);
        }

        public IList<Tarefa> ObterTodos() { return _repository.GetAll(); }
    }
}