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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Permite visualizar a lista de usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var usuarios = _usuarioRepository.Get();

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Permite a consulta de um usuário específico.
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPor(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetBy(id);

                if (usuario is null) return NotFound("Usuário não encontrado");

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cadastra um usuário.
        /// </summary>
        /// <param name="usuario">Usuário a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                if (usuario is null) return BadRequest("Dados incompletos");

                _usuarioRepository.Create(usuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza um usuário específico.
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            try
            {
                var usuarioBuscado = _usuarioRepository.GetBy(id);

                if (usuarioBuscado is null) return BadRequest("Usuário não identificado");

                _usuarioRepository.Update(id, usuario);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deleta um usuário específico.
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var usuarioBuscado = _usuarioRepository.GetBy(id);

                if (usuarioBuscado is null) return BadRequest("Usuário não identificado");

                _usuarioRepository.Delete(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}