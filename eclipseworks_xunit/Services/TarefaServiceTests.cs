using Xunit;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using Moq;
using System.ComponentModel.DataAnnotations;
using eclipseworks_teste.ViewModel;

namespace eclipseworks_teste.Services.Tests
{

    public class TarefaServiceTests
    {
        private ITarefaService tarefaService;
        public TarefaServiceTests()
        {
            tarefaService = new TarefaService(RepositoryMock.TarefaRepositoryMock.Object, RepositoryMock.UsuarioRepositoryMock.Object, RepositoryMock.HistoricoTarefaRepositoryMock.Object);
        }

        [Fact()]
        public void GetAllTest()
        {
            var result = tarefaService.GetAll();
            Assert.NotEqual(result, null);
        }

        [Fact()]
        public void GetAllByProjectIdTest()
        {
            var result = tarefaService.GetAllByProjectId(1);
            Assert.NotEqual(result, null);
        }

        [Fact()]
        public void GetTarefasPorUsuario30diasTest()
        {
            var result = tarefaService.GetTarefasPorUsuario30dias(1);
            Assert.NotEqual(result, null);
        }

        [Fact()]
        public void RemoveTarefaTest()
        {
            var result = tarefaService.RemoveTarefa(1);
            Assert.Equal(result, ValidationResult.Success);
        }

        [Fact()]
        public void AddTarefaTest()
        {
            var tarefa = new Tarefa()
            {
                Titulo = "",
                Descricao = "",
                CodUsuario = 1,
                DataVencimento = DateTime.Now,
                Prioridade = PrioridadeTarefa.Media,
                CodProjeto = 1,
                Status = StatusTarefa.Pendente
            };
            var validation = tarefaService.AddTarefa(tarefa);
            Assert.Equal(validation, ValidationResult.Success);
        }

        [Fact()]
        public void AddComentarioTest()
        {
            var hist = new ComentarioVM
            {
                Comentario = "Comentário"
            };
            var result = tarefaService.AddComentario(hist, 1, 1);
            Assert.Equal(result, ValidationResult.Success);
        }

        [Fact()]
        public void EditTarefaTest()
        {
            var tarefa = new TarefaVM()
            {
                Titulo = "Titulo da Tarefa",
                Descricao = "Descrição da tarefa",
                DataVencimento = DateTime.Now,
                Status = StatusTarefa.EmAndamento
            };
            var result = tarefaService.EditTarefa(tarefa, 1, 1);
            Assert.Equal(result.Titulo, tarefa.Titulo);
            Assert.Equal(result.Descricao, tarefa.Descricao);
            Assert.Equal(result.DataVencimento, tarefa.DataVencimento);
            Assert.Equal(result.Status, tarefa.Status);
        }
    }
}