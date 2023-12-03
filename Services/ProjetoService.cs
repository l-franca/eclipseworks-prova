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

        public IList<Projeto> GetAllProjetos() { return _repository.GetAllProjetos(); }
        public IList<Projeto> GetByUserId(long userId) { return _repository.GetByUserId(userId); }
        public Projeto AddProjeto(Projeto projeto) { _repository.Save(projeto); return projeto; }
    }
}