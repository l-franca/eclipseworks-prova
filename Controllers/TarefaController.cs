using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworks_teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _service;

        public TarefaController(EclipseContext context)
        {
            _service = new TarefaService(context);
        }
        [HttpGet]
        public IEnumerable<Tarefa> GetTarefa()
        {
            return _service.ObterTodos();
        }
    }
}