namespace eclipseworks_teste.Entities
{
    public class Projeto
    {
        public long CodProjeto { get; set; }
        public long CodUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }

        public virtual IList<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
        public virtual Usuario Usuario { get; set; }

    }
}
