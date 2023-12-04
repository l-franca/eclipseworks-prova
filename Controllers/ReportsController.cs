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
        private readonly ITarefaService _tarefaService;
        private readonly IUsuarioService _usuarioService;
        private readonly IProjetoService _projetoService;
        private readonly IHistoricoTarefaService _histtarefaService;

        public ReportsController(ITarefaService tarefaService, IUsuarioService usuarioService, IProjetoService projetoService, IHistoricoTarefaService historicoTarefaService)
        {
            _tarefaService = tarefaService;
            _usuarioService = usuarioService;
            _projetoService = projetoService;
            _histtarefaService = historicoTarefaService;
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