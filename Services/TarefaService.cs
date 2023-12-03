using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using eclipseworks_teste.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.Services
{
    public class TarefaService
    {
        private readonly TarefaRepository _repository;
        private readonly HistoricoTarefaRepository _histRepository;
        public TarefaService(EclipseContext context) { 

            _repository = new TarefaRepository(context);
            _histRepository = new HistoricoTarefaRepository(context);
        }

        public IList<Tarefa> ObterTodos() { return _repository.GetAll(); }

        public void RemoveTarefa(long codTarefa) { _repository.RemoveById(codTarefa); }

        public ValidationResult AddTarefa(Tarefa tarefa) {
            if (_repository.CountPerProject(tarefa.CodProjeto) <= 20) {
                if (tarefa.DataVencimento.Date >= DateTime.Now.Date) {
                    _repository.Save(tarefa);
                    return ValidationResult.Success;
                }
                return new ValidationResult("Data de vencimento inválida", new string[] { "DataVencimento" });
            }

            return new ValidationResult("Projeto já possui 20 tarefas!");
        }

        public void AddComentario(ComentarioVM comentarioVM, long codTarefa, long codUsuario) {
            _histRepository.Save(new HistoricoTarefa
            {
                CodTarefa = codTarefa,
                CodUsuario = codUsuario,
                Comentario = comentarioVM.Comentario,
                DataModificacao = DateTime.Now,
                StatusHistorico = StatusHistorico.Comentario
            });
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