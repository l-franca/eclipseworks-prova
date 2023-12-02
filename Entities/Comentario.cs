namespace eclipseworks_teste.Entities
{
    public class Comentario
    {
        public long CodComentario { get; set; }
        public string DescComentario { get; set; }
        public long CodTarefa { get; set; }
        public long VersaoTarefa { get; set; }
        public long CodUsuario { get; set; }
        public DateTime DataAlteracao { get; set; }

    }
}
