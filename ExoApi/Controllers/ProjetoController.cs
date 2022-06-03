using ExoApi.Models;
using ExoApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository; 

        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var projetos = _projetoRepository.Get();
            
            return Ok(projetos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPor(int id)
        {
            var projeto = _projetoRepository.GetBy(id);
            
            if(projeto is null) return NotFound("Projeto não encontrado");

            return Ok(projeto);
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            if(projeto is null) return BadRequest("Dados incompletos");

             _projetoRepository.Create(projeto);

             return StatusCode(201);      
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            var projetoBuscado = _projetoRepository.GetBy(id);

            if(projetoBuscado is null) return BadRequest("Projeto não identificado");

            _projetoRepository.Update(id, projeto);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var projetoBuscado = _projetoRepository.GetBy(id);

            if(projetoBuscado is null) return BadRequest("Projeto não identificado");

            _projetoRepository.Delete(id);

            return StatusCode(204);
        }
    }
}