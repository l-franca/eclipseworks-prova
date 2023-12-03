using eclipseworks_teste.Entities;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.ViewModel
{
    public class ProjetoVM
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Título do Projeto")]
        [StringLength(255)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição do Projeto")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data do Projeto")]
        public DateTime Data { get; set; }
    }
}
