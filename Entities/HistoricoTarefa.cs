namespace eclipseworks_teste.Entities
{
    public class HistoricoTarefa
    {
        public long CodHistorico { get; set; }
        public long CodTarefa { get; set; }
        public long CodUsuario { get; set; }
        public virtual Tarefa Tarefa { get; set; }
        public virtual Usuario Usuario { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Comentario { get; set; }
        public StatusTarefa? StatusTarefa { get; set; }
        public DateTime? DataVencimento { get; set; }
        public DateTime DataModificacao { get; set; }
        public StatusHistorico StatusHistorico { get; set; }
    }

    public enum StatusHistorico { 
        Atualizacao,
        Comentario,
        Exclusao
    }
}
