using Xunit;
using eclipseworks_teste.Repositories;
using Moq;
using eclipseworks_teste.Entities;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.Services.Tests
{
    public class ProjetoServiceTests
    {
        private IProjetoService projetoService;
        public ProjetoServiceTests()
        {
            projetoService = new ProjetoService(RepositoryMock.ProjetoRepositoryMock.Object);
        }

        [Fact()]
        public void GetAllProjetosTest()
        {
            var listProjetos = projetoService.GetAllProjetos();
            Assert.Empty(listProjetos);
        }

        [Fact()]
        public void GetByUserIdTest()
        {
            var listProjetos = projetoService.GetByUserId(1);
            Assert.Empty(listProjetos);
        }

        [Fact()]
        public void AddProjetoTest()
        {
            var projeto = DataMock.Projetos.FirstOrDefault();
            var result = projetoService.AddProjeto(projeto);
            Assert.Equal(projeto.CodUsuario, result.CodUsuario);
            Assert.Equal(projeto.Data, result.Data);
            Assert.Equal(projeto.Descricao, result.Descricao);
            Assert.Equal(projeto.Titulo, result.Titulo);
        }

        [Fact()]
        public void RemoveProjetoTest()
        {
            var result = projetoService.RemoveProjeto(1);
            Assert.Equal(result, ValidationResult.Success);
        }
    }
}