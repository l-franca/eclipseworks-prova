using eclipseworks_teste.Entities;
using eclipseworks_teste.Repositories;
using Moq;

namespace eclipseworks_teste.Services.Tests
{
    public static class DataMock
    {
        public static List<Usuario> Usuarios
        {
            get
            {
                var list = new List<Usuario>() {
                    new Usuario {
                        CodUsuario = 1,
                        Nome = "Leandro Franca",
                        Cargo = CargoUsuario.Gerente
                    },
                    new Usuario
                    {
                        CodUsuario = 2,
                        Nome = "Bob Franca",
                        Cargo = CargoUsuario.Padrao
                    }
                };
                return list;
            }
        }

        public static List<Projeto> Projetos
        {
            get
            {
                var list = new List<Projeto>() {
                    new Projeto{ 
                        CodProjeto = 1,
                        CodUsuario = 1,
                        Data = DateTime.Now,
                        Descricao = "Descrição do Projeto 1",
                        Titulo = "Projeto 1"
                    },
                    new Projeto{
                        CodProjeto = 2,
                        CodUsuario = 2,
                        Data = DateTime.Now,
                        Descricao = "Descrição do Projeto 2",
                        Titulo = "Projeto 2"
                    },
                    new Projeto{
                        CodProjeto = 3,
                        CodUsuario = 1,
                        Data = DateTime.Now,
                        Descricao = "Descrição do Projeto 3",
                        Titulo = "Projeto 3"
                    }
                };
                return list;
            }
        }

        public static List<Tarefa> Tarefas
        {
            get
            {
                var list = new List<Tarefa>() {
                    new Tarefa { 
                        CodTarefa = 1,
                        CodProjeto = 1,
                        CodUsuario = 1,
                        Titulo = "Tarefa 1",
                        Descricao = "Descrição da Tarefa 1",
                        Status = StatusTarefa.Pendente,
                        Prioridade = PrioridadeTarefa.Media,
                        DataVencimento = DateTime.Now.AddDays(15)
                    },
                    new Tarefa {
                        CodTarefa = 2,
                        CodProjeto = 1,
                        CodUsuario = 1,
                        Titulo = "Tarefa 2",
                        Descricao = "Descrição da Tarefa 2",
                        Status = StatusTarefa.Pendente,
                        Prioridade = PrioridadeTarefa.Media,
                        DataVencimento = DateTime.Now.AddDays(10)
                    },
                    new Tarefa {
                        CodTarefa = 3,
                        CodProjeto = 1,
                        CodUsuario = 1,
                        Titulo = "Tarefa 3",
                        Descricao = "Descrição da Tarefa 3",
                        Status = StatusTarefa.Concluida,
                        Prioridade = PrioridadeTarefa.Media,
                        DataVencimento = DateTime.Now.AddDays(5)
                    },
                    new Tarefa {
                        CodTarefa = 4,
                        CodProjeto = 2,
                        CodUsuario = 2,
                        Titulo = "Tarefa 4",
                        Descricao = "Descrição da Tarefa 4",
                        Status = StatusTarefa.EmAndamento,
                        Prioridade = PrioridadeTarefa.Alta,
                        DataVencimento = DateTime.Now.AddDays(3)
                    },
                    new Tarefa {
                        CodTarefa = 5,
                        CodProjeto = 3,
                        CodUsuario = 2,
                        Titulo = "Tarefa 5",
                        Descricao = "Descrição da Tarefa 5",
                        Status = StatusTarefa.Pendente,
                        Prioridade = PrioridadeTarefa.Baixa,
                        DataVencimento = DateTime.Now.AddDays(20)
                    },
                };
                return list;
            }
        }

        public static List<HistoricoTarefa> HistoricoTarefas
        {
            get
            {
                var list = new List<HistoricoTarefa>() {
                    new HistoricoTarefa {
                        CodTarefa = 4,
                        CodUsuario = 1,
                        DataModificacao = DateTime.Now,
                        Descricao = "nova descrição tarefa 4",
                        StatusHistorico = StatusHistorico.Atualizacao,
                        StatusTarefa = StatusTarefa.Concluida,
                        DataVencimento = DateTime.Now.AddDays(5),
                        Titulo = "novo título tarefa 4"
                    },
                    new HistoricoTarefa {
                        CodTarefa = 1,
                        CodUsuario = 2,
                        DataModificacao = DateTime.Now,
                        Descricao = "nova descrição tarefa 1",
                        StatusHistorico = StatusHistorico.Atualizacao,
                        StatusTarefa = StatusTarefa.EmAndamento,
                        DataVencimento = DateTime.Now.AddDays(30),
                        Titulo = "novo título tarefa 1"
                    }
                };
                return list;
            }
        }

        public static List<HistoricoTarefa> Comentario
        {
            get
            {
                var list = new List<HistoricoTarefa>() {
                    new HistoricoTarefa {
                        Comentario = "Comentario tarefa 1",
                        CodTarefa = 1,
                        CodUsuario = 1,
                        StatusHistorico = StatusHistorico.Comentario,
                        DataModificacao = DateTime.Now
                    },
                };
                return list;
            }
        }
    }
}
