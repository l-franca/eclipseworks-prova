using eclipseworks_teste.Entities;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.ViewModel
{
    public class ComentarioVM
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Comentário")]
        public string Comentario { get; set; }
    }
}
