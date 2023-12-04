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
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _service;

        public ProjetoController(IProjetoService projetoService)
        {
            _service = projetoService;
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

        //TESTAR
        [HttpDelete("{codProjeto:long}")]
        public IActionResult RemoveProjeto(long codProjeto)
        {
            var validations = _service.RemoveProjeto(codProjeto); 
            if (validations == ValidationResult.Success)
            {
                return Ok();
            }
            return BadRequest(validations);
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