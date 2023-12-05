using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using eclipseworks_teste.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworks_teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _service = usuarioService;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return _service.ObterTodos();
        }

        [HttpPost]
        public IActionResult Save(UsuarioVM usuarioVM) {
            if (ModelState.IsValid) {
                var usuario = _service.AddUsuario(new Usuario { 
                    Nome = usuarioVM.Nome,
                    Cargo = usuarioVM.Cargo
                }) ;
                return Ok(usuario);
            }

            return BadRequest(ModelState);
        }
    }
}