using eclipseworks_teste.Entities;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.ViewModel
{
    public class HistoricoTarefaVM
    {
        public long CodTarefa { get; set; }
        public long CodProjeto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Título da tarefa")]
        [StringLength(255)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição da tarefa")]
        public string Descricao { get; set; }

        [Required]
        [EnumDataType(typeof(StatusTarefa), ErrorMessage = "Status inválido")]
        public StatusTarefa Status { get; set; }

        public long CodUsuario { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVencimento { get; set; }

        [Required]
        [EnumDataType(typeof(PrioridadeTarefa), ErrorMessage = "Prioridade inválida")]
        public PrioridadeTarefa Prioridade { get; set; }
    }
}
