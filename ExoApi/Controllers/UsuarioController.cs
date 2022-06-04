using ExoApi.Models;
using ExoApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

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