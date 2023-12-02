namespace eclipseworks_teste.Entities
{
    public class Tarefa
    {
        public long CodTarefa { get; set; }
        public long CodProjeto { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public long CodUsuario { get; set; }
        public DateTime Data { get; set; }
        public long Versao { get; set; }

    }
}
