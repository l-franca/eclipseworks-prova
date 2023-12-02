using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;

namespace eclipseworks_teste.Services
{
    public class ProjetoService
    {
        private readonly ProjetoRepository _repository;
        public ProjetoService(EclipseContext context) { 
            _repository = new ProjetoRepository(context);
        }

        public IList<Projeto> ObterTodos() { return _repository.GetAll(); }
    }
}