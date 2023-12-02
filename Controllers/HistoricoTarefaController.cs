using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworks_teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HistoricoTarefaController : ControllerBase
    {
        private readonly HistoricoTarefaService _service;

        public HistoricoTarefaController(EclipseContext context)
        {
            _service = new HistoricoTarefaService(context);
        }
        [HttpGet]
        public IEnumerable<HistoricoTarefa> GetTarefa()
        {
            return _service.ObterTodos();
        }
    }
}