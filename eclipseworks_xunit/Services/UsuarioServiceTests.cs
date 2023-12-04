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

namespace eclipseworks_teste.Services.Tests
{
    public class UsuarioServiceTests
    {
        private IUsuarioService usuarioService;
        public UsuarioServiceTests()
        {
            var usuarioRepository = new Mock<IUsuarioRepository>();
            usuarioRepository.Setup(u => u.CheckIfGerente(It.IsAny<long>())).Returns(true);
            usuarioRepository.Setup(u => u.Save(It.IsAny<Usuario>()));

            usuarioService = new UsuarioService(usuarioRepository.Object);
        }

        [Fact()]
        public void UsuarioServiceTest()
        {
            //Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void ObterTodosTest()
        {
            //Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void CheckIfGerenteTest()
        {

            //Assert.True(false, "This test needs an implementation");
        }

        [Fact()]
        public void AddUsuarioTest()
        {
            var user = new Usuario()
            {
                Nome = "Elias",
                Cargo = CargoUsuario.Gerente
            };
            var retUser = usuarioService.AddUsuario(user);
            Assert.Equal(user.Nome, retUser.Nome);
            Assert.Equal(user.Cargo, retUser.Cargo);
        }
    }
}