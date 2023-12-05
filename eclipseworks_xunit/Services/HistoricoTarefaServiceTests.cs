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
        public HistoricoTarefaServiceTests()
        {
            histtarefaService = new HistoricoTarefaService(RepositoryMock.HistoricoTarefaRepositoryMock.Object, RepositoryMock.UsuarioRepositoryMock.Object);
        }

        [Fact()]
        public void ObterTodosTest()
        {
            var result = histtarefaService.ObterTodos();
            Assert.NotEqual(result, null);
        }

        [Fact()]
        public void GetAllComentariosTest()
        {
            var result = histtarefaService.GetAllComentarios(1, 4);
            Assert.NotEqual(result, null);
        }

        [Fact()]
        public void GetAllUpdatesTest()
        {
            var result = histtarefaService.GetAllUpdates(2, 6);
            Assert.NotEqual(result, null);
        }
    }
}