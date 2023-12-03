namespace eclipseworks_teste.Entities
{
    public class Usuario
    {
        public long CodUsuario { get; set; }
        public string Nome { get; set; }
        public CargoUsuario Cargo { get; set; }

        public virtual IList<Projeto> Projeto { get; set; } = new List<Projeto>();
        public virtual IList<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
        public virtual IList<HistoricoTarefa> HistoricoTarefas { get; set; } = new List<HistoricoTarefa>();


    }

    public enum CargoUsuario { 
        Padrao,
        Gerente
    }
}
