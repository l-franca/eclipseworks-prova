using Xunit;
using eclipseworks_teste.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using Moq;

namespace eclipseworks_teste.Services.Tests
{
    public class HistoricoTarefaServiceTests
    {
        private IHistoricoTarefaService histtarefaService;
        private Mock<IHistoricoTarefaRepository> histtarefaRepository;
        private Mock<IUsuarioRepository> usuarioRepository;
        public HistoricoTarefaServiceTests()
        {
            histtarefaRepository = RepositoryMock.HistoricoTarefaRepositoryMock;
            usuarioRepository = RepositoryMock.UsuarioRepositoryMock;
            histtarefaService = new HistoricoTarefaService(histtarefaRepository.Object, usuarioRepository.Object);
        }

        [Fact()]
        public void ObterTodosTest()
        {
            var result = histtarefaService.ObterTodos();
            Assert.NotEmpty(result);
        }

        [Fact()]
        public void GetAllComentariosTest()
        {
            usuarioRepository.Setup(u => u.CheckIfGerente(It.IsAny<long>())).Returns(false);
            var result = histtarefaService.GetAllComentarios(2, 4);
            histtarefaRepository.Verify(x=>x.GetAllComentarios(It.IsAny<long>()), Times.Never);
            Assert.Empty(result);
        }

        [Fact()]
        public void GetAllUpdatesTest()
        {
            usuarioRepository.Setup(u => u.CheckIfGerente(It.IsAny<long>())).Returns(false);
            var result = histtarefaService.GetAllUpdates(2, 6);
            histtarefaRepository.Verify(x => x.GetAllUpdates(It.IsAny<long>()), Times.Never);
            Assert.Empty(result);
        }
    }
}