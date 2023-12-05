using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using Moq;

namespace eclipseworks_teste.Services.Tests
{
    public static class RepositoryMock
    {
        public static Mock<IUsuarioRepository> UsuarioRepositoryMock
        {
            get
            {
                var usuarioRepository = new Mock<IUsuarioRepository>();
                usuarioRepository.Setup(u => u.CheckIfGerente(It.IsAny<long>())).Returns(true);
                usuarioRepository.Setup(u => u.Save(It.IsAny<Usuario>()));
                usuarioRepository.Setup(u => u.GetAll()).Returns(DataMock.Usuarios);
                return usuarioRepository;
            }
        }

        public static Mock<IProjetoRepository> ProjetoRepositoryMock
        {
            get
            {
                var projetoRepository = new Mock<IProjetoRepository>();
                projetoRepository.Setup(u => u.Save(It.IsAny<Projeto>()));
                projetoRepository.Setup(u => u.GetAllProjetos()).Returns(DataMock.Projetos);
                projetoRepository.Setup(u => u.GetByUserId(It.IsAny<long>())).Returns(DataMock.Projetos);
                projetoRepository.Setup(u => u.Count(It.IsAny<Projeto>())).Returns(It.IsAny<int>());
                projetoRepository.Setup(u => u.CanBeRemoved(It.IsAny<long>())).Returns(It.IsAny<bool>());
                return projetoRepository;
            }
        }

        public static Mock<IHistoricoTarefaRepository> HistoricoTarefaRepositoryMock
        {
            get
            {
                var histtarefaRepository = new Mock<IHistoricoTarefaRepository>();
                histtarefaRepository.Setup(u => u.Save(It.IsAny<HistoricoTarefa>()));
                histtarefaRepository.Setup(u => u.Update(It.IsAny<HistoricoTarefa>()));
                histtarefaRepository.Setup(u => u.GetAllComentarios(It.IsAny<long>())).Returns(DataMock.HistoricoTarefas);
                histtarefaRepository.Setup(u => u.GetAllUpdates(It.IsAny<long>())).Returns(DataMock.HistoricoTarefas);
                histtarefaRepository.Setup(u => u.GetAll()).Returns(DataMock.HistoricoTarefas);
                return histtarefaRepository;
            }
        }

        public static Mock<ITarefaRepository> TarefaRepositoryMock
        {
            get
            {
                var tarefaRepository = new Mock<ITarefaRepository>();
                tarefaRepository.Setup(u => u.Save(It.IsAny<Tarefa>()));
                tarefaRepository.Setup(u => u.CountPerProject(It.IsAny<long>())).Returns(It.IsAny<int>());
                tarefaRepository.Setup(u => u.Update(It.IsAny<Tarefa>()));
                tarefaRepository.Setup(u => u.GetById(It.IsAny<long>())).Returns(DataMock.Tarefas.FirstOrDefault());
                tarefaRepository.Setup(u => u.Remove(It.IsAny<Tarefa>()));
                tarefaRepository.Setup(u => u.GetTarefasPorUsuario30dias(It.IsAny<long>())).Returns(DataMock.Tarefas);
                tarefaRepository.Setup(u => u.GetAll()).Returns(DataMock.Tarefas);
                tarefaRepository.Setup(u => u.GetAllByProject(It.IsAny<long>())).Returns(DataMock.Tarefas);
                return tarefaRepository;
            }
        }
    }
}
