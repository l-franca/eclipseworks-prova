using eclipseworks_teste.Entities;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.ViewModel
{
    public class UsuarioVM
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome do usuário")]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [EnumDataType(typeof(CargoUsuario), ErrorMessage = "Cargo inválido")]
        public CargoUsuario Cargo { get; set; }
    }
}
