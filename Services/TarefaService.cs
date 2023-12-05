using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using eclipseworks_teste.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.Services
{
    public interface ITarefaService
    {
        ValidationResult AddComentario(ComentarioVM comentarioVM, long codTarefa, long codUsuario);
        ValidationResult AddTarefa(Tarefa tarefa);
        Tarefa EditTarefa(TarefaVM tarefaVM, long codTarefa, long codUsuario);
        IList<Tarefa> GetAll();
        IList<Tarefa> GetAllByProjectId(long codProjeto);
        IList<Tarefa> GetTarefasPorUsuario30dias(long usuarioId);
        ValidationResult RemoveTarefa(long codTarefa);
    }

    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHistoricoTarefaRepository _histRepository;
        public TarefaService(ITarefaRepository repository, IUsuarioRepository usuarioRepository, IHistoricoTarefaRepository historicoTarefaRepository)
        {

            _repository = repository;
            _usuarioRepository = usuarioRepository;
            _histRepository = historicoTarefaRepository;

        }

        public IList<Tarefa> GetAll() { return _repository.GetAll(); }
        public IList<Tarefa> GetAllByProjectId(long codProjeto) { return _repository.GetAllByProject(codProjeto); }

        public IList<Tarefa> GetTarefasPorUsuario30dias(long usuarioId)
        {
            if (_usuarioRepository.CheckIfGerente(usuarioId))
            {
                return _repository.GetTarefasPorUsuario30dias(usuarioId);
            }
            return new List<Tarefa>();
        }

        public ValidationResult RemoveTarefa(long codTarefa) {
            _repository.RemoveById(codTarefa);
            return ValidationResult.Success;

        }

        public ValidationResult AddTarefa(Tarefa tarefa)
        {
            if (_repository.CountPerProject(tarefa.CodProjeto) <= 20)
            {
                if (tarefa.DataVencimento.Date >= DateTime.Now.Date)
                {
                    _repository.Save(tarefa);
                    return ValidationResult.Success;
                }
                return new ValidationResult("Data de vencimento inválida", new string[] { "DataVencimento" });
            }

            return new ValidationResult("Projeto já possui 20 tarefas!");
        }

        public ValidationResult AddComentario(ComentarioVM comentarioVM, long codTarefa, long codUsuario)
        {
            _histRepository.Save(new HistoricoTarefa
            {
                CodTarefa = codTarefa,
                CodUsuario = codUsuario,
                Comentario = comentarioVM.Comentario,
                DataModificacao = DateTime.Now,
                StatusHistorico = StatusHistorico.Comentario
            });
            return ValidationResult.Success;
        }

        public Tarefa EditTarefa(TarefaVM tarefaVM, long codTarefa, long codUsuario)
        {
            var tarefa = _repository.GetById(codTarefa);

            var historico = new HistoricoTarefa
            {
                CodTarefa = tarefa.CodTarefa,
                CodUsuario = codUsuario,
                DataModificacao = DateTime.Now,
                DataVencimento = tarefa.DataVencimento,
                Descricao = tarefa.Descricao,
                StatusHistorico = StatusHistorico.Atualizacao,
                StatusTarefa = tarefa.Status,
                Titulo = tarefa.Titulo
            };

            _histRepository.Save(historico);


            tarefa.Titulo = tarefaVM.Titulo;
            tarefa.Descricao = tarefaVM.Descricao;
            tarefa.DataVencimento = tarefaVM.DataVencimento;
            tarefa.Status = tarefaVM.Status;

            _repository.Update(tarefa);

            return tarefa;
        }
    }
}