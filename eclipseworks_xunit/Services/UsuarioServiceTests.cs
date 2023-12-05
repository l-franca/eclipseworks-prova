using Xunit;
using eclipseworks_teste.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eclipseworks_teste.Repositories;
using Moq;
using eclipseworks_teste.Entities;
using NuGet.Frameworks;

namespace eclipseworks_teste.Services.Tests
{
    public class UsuarioServiceTests
    {
        private IUsuarioService usuarioService;
        public UsuarioServiceTests()
        {
            usuarioService = new UsuarioService(RepositoryMock.UsuarioRepositoryMock.Object);
        }

        [Fact()]
        public void ObterTodosTest()
        {
            var userList = usuarioService.ObterTodos();
            Assert.NotEqual(userList, null);
        }

        [Fact()]
        public void CheckIfGerenteTest()
        {
            var user = usuarioService.CheckIfGerente(1);
            Assert.True(user);
        }

        [Fact()]
        public void AddUsuarioTest()
        {
            var user = DataMock.Usuarios.FirstOrDefault();
            var retUser = usuarioService.AddUsuario(user);
            Assert.Equal(user.Nome, retUser.Nome);
            Assert.Equal(user.Cargo, retUser.Cargo);
        }
    }
}