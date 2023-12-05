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
        private Mock<IHistoricoTarefaRepository> histtarefaRepository;
        public TarefaServiceTests()
        {
            histtarefaRepository = RepositoryMock.HistoricoTarefaRepositoryMock;
            tarefaService = new TarefaService(RepositoryMock.TarefaRepositoryMock.Object, RepositoryMock.UsuarioRepositoryMock.Object, histtarefaRepository.Object);
        }

        [Fact()]
        public void GetAllTest()
        {
            var result = tarefaService.GetAll();
            Assert.Empty(result);
        }

        [Fact()]
        public void GetAllByProjectIdTest()
        {
            var result = tarefaService.GetAllByProjectId(1);
            Assert.Empty(result);
        }

        [Fact()]
        public void GetTarefasPorUsuario30diasTest()
        {
            var result = tarefaService.GetTarefasPorUsuario30dias(1);
            Assert.Empty(result);
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
            var validation = tarefaService.AddTarefa(DataMock.Tarefas.FirstOrDefault());
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
            histtarefaRepository.Verify(x=>x.Save(It.IsAny<HistoricoTarefa>()), Times.Once);
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