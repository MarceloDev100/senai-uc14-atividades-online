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
            var usuarios = _usuarioRepository.Get();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPor(int id)
        {
            var usuario = _usuarioRepository.GetBy(id);

            if(usuario is null) return NotFound("Usuário não encontrado");

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
             if(usuario is null) return BadRequest("Dados incompletos");

             _usuarioRepository.Create(usuario);

             return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            var usuarioBuscado = _usuarioRepository.GetBy(id);

            if(usuarioBuscado is null) return BadRequest("Usuário não identificado");

            _usuarioRepository.Update(id, usuario);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var usuarioBuscado = _usuarioRepository.GetBy(id);

            if(usuarioBuscado is null) return BadRequest("Usuário não identificado");

            _usuarioRepository.Delete(id);

            return StatusCode(204);
        }
    }
}