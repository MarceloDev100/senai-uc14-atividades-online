using ExoApi.Models;
using ExoApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{  
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoController(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        /// <summary>
        /// Permite visualizar a lista de projetos cadastrados.
        /// </summary>
        /// <returns>Lista de projetos</returns>
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

        /// <summary>
        /// Permite a consulta de um projeto específico.
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns>Retorna o projeto</returns>
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

        /// <summary>
        /// Cadastra um projeto.
        /// </summary>
        /// <param name="projeto">Projeto a ser cadastrado</param>
        /// <returns></returns>
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

        
        /// <summary>
        /// Atualiza um projeto específico.
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <param name="projeto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Deleta um projeto específico, de acordo com o nível (tipo) de permissão do usuário.
        /// </summary>
        /// <param name="id">Identificador do projeto</param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
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