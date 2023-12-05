using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using eclipseworks_teste.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace eclipseworks_teste.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _service;

        public TarefaController(ITarefaService tarefaService)
        {
            _service = tarefaService;
        }

        [HttpGet]
        public IList<Tarefa> GetAllTarefa()
        {
            return _service.GetAll();
        }

        [HttpGet("{codProjeto:long}")]
        public IList<Tarefa> GetAllByProjeto(long codProjeto)
        {
            return _service.GetAllByProjectId(codProjeto);
        }

        [HttpDelete("{codTarefa:long}")]
        public void RemoveTarefa(long codTarefa)
        {
            _service.RemoveTarefa(codTarefa);
        }

        [HttpPost("{codProjeto:long}/{codUsuario:long}")]
        public IActionResult Save(TarefaVM tarefaVM, long codProjeto, long codUsuario)
        {
            if (ModelState.IsValid)
            {
                var tarefa = new Tarefa
                {
                    CodProjeto = codProjeto,
                    CodUsuario = codUsuario,
                    Titulo = tarefaVM.Titulo,
                    Descricao = tarefaVM.Descricao,
                    DataVencimento = tarefaVM.DataVencimento,
                    Prioridade = tarefaVM.Prioridade,
                    Status = tarefaVM.Status
                };
                var validations = _service.AddTarefa(tarefa);
                if (validations == ValidationResult.Success)
                {
                    return Ok(tarefa);
                }
                return BadRequest(validations);
            }
            return BadRequest(ModelState);
        }

        [HttpPost("{codTarefa:long}/{codUsuario:long}")]
        public IActionResult AddComentario(ComentarioVM comentarioVM, long codTarefa, long codUsuario) 
        {
            if (ModelState.IsValid)
            {
                _service.AddComentario(comentarioVM, codTarefa, codUsuario);
                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{codTarefa:long}/{codUsuario:long}")]
        public IActionResult EditarTarefa(TarefaVM tarefaVM, long codTarefa, long codUsuario)
        {
            if (ModelState.IsValid)
            {
                _service.EditTarefa(tarefaVM, codTarefa, codUsuario);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}