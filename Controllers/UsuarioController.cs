using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworks_teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(EclipseContext context)
        {
            _service = new UsuarioService(context);
        }
        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return _service.ObterTodos();
        }
    }
}