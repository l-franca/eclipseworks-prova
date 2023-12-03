namespace eclipseworks_teste.Entities
{
    public class Tarefa
    {
        public long CodTarefa { get; set; }
        public long CodProjeto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public long CodUsuario { get; set; }
        public DateTime DataVencimento { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public virtual Projeto Projeto { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual IList<HistoricoTarefa> HistoricoTarefa { get; set; } = new List<HistoricoTarefa>();

    }

    public enum StatusTarefa { 
        Pendente,
        EmAndamento,
        Concluida
    }

    public enum PrioridadeTarefa { 
        Baixa,
        Media,
        Alta
    }
}
