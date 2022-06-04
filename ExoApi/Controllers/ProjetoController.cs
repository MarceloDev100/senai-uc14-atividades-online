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
            try
            {
                var projetos = _projetoRepository.Get();

                return Ok(projetos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPor(int id)
        {
            try
            {
                var projeto = _projetoRepository.GetBy(id);

                if (projeto is null) return NotFound("Projeto não encontrado");

                return Ok(projeto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            try
            {
                if (projeto is null) return BadRequest("Dados incompletos");

                _projetoRepository.Create(projeto);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            try
            {
                var projetoBuscado = _projetoRepository.GetBy(id);

                if (projetoBuscado is null) return BadRequest("Projeto não identificado");

                _projetoRepository.Update(id, projeto);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var projetoBuscado = _projetoRepository.GetBy(id);

                if (projetoBuscado is null) return BadRequest("Projeto não identificado");

                _projetoRepository.Delete(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}