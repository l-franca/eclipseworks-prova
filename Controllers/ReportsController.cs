using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using Microsoft.AspNetCore.Mvc;

namespace eclipseworks_teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReportsController : ControllerBase
    {
        private readonly TarefaService _tarefaService;
        private readonly UsuarioService _usuarioService;
        private readonly ProjetoService _projetoService;
        private readonly HistoricoTarefaService _histtarefaService;

        public ReportsController(EclipseContext context)
        {
            _tarefaService = new TarefaService(context);
            _usuarioService = new UsuarioService(context);
            _projetoService = new ProjetoService(context);
            _histtarefaService = new HistoricoTarefaService(context);
        }

        [HttpGet("{usuarioId:long}")]
        public IList<Tarefa> GetTarefasConcluidasPorUsuario30dias(long usuarioId)
        {
            return _tarefaService.GetTarefasPorUsuario30dias(usuarioId);
        }

        [HttpGet("{usuarioId:long}/{tarefaId:long}")]
        public IList<HistoricoTarefa> GetAllComentarios(long usuarioId, long tarefaId)
        {

            return _histtarefaService.GetAllComentarios(usuarioId, tarefaId);
        }

        [HttpGet("{usuarioId:long}/{tarefaId:long}")]
        public IList<HistoricoTarefa> GetAllUpdates(long usuarioId, long tarefaId)
        {
            return _histtarefaService.GetAllUpdates(usuarioId, tarefaId);
        }
    }
}