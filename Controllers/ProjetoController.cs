using eclipseworks_teste.Context;
using eclipseworks_teste.Entities;
using eclipseworks_teste.Services;
using eclipseworks_teste.ViewModel;
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
        public IEnumerable<Projeto> GetAllProjetos()
        {
            return _service.GetAllProjetos();
        }

        [HttpGet("{codUsuario:long}")]
        public IEnumerable<Projeto> GetProjetosByUser(long codUsuario)
        {
            return _service.GetByUserId(codUsuario);
        }
        
        [HttpPost("{codUsuario:long}")]
        public IActionResult Save(ProjetoVM projetoVM, long codUsuario)
        {
            if (ModelState.IsValid)
            {
                var projeto = _service.AddProjeto(new Projeto
                {
                    CodUsuario = codUsuario,
                    Titulo = projetoVM.Titulo,
                    Descricao = projetoVM.Descricao,
                    Data = DateTime.Now
                });
                return Ok(projeto);
            }

            return BadRequest(ModelState);
        }


    }
}