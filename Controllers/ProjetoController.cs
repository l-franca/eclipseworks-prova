using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworks_teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoService _service;

        public ProjetoController(EclipseContext context)
        {
            _service = new ProjetoService(context);
        }
        [HttpGet]
        public IEnumerable<Projeto> GetProjetos()
        {
            return _service.ObterTodos();
        }
    }
}