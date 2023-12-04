using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.Services
{
    public interface IProjetoService
    {
        Projeto AddProjeto(Projeto projeto);
        IList<Projeto> GetAllProjetos();
        IList<Projeto> GetByUserId(long userId);
        ValidationResult RemoveProjeto(long codProjeto);
    }

    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _repository;
        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _repository = projetoRepository;
        }

        public IList<Projeto> GetAllProjetos() { return _repository.GetAllProjetos(); }
        public IList<Projeto> GetByUserId(long userId) { return _repository.GetByUserId(userId); }
        public Projeto AddProjeto(Projeto projeto) { _repository.Save(projeto); return projeto; }
        public ValidationResult RemoveProjeto(long codProjeto)
        {
            if (_repository.CanBeRemoved(codProjeto))
            {
                _repository.RemoveById(codProjeto);

                return ValidationResult.Success;
            }
            return new ValidationResult("Não é possível excluir um projeto com tarefas não concluídas. Favor concluir ou removê-las.");
        }
    }
}