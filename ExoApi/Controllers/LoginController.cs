using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ExoApi.Models;
using ExoApi.Repositories.Interfaces;
using ExoApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Permite realizar o login de um usuário no sistema.
        /// </summary>
        /// <param name="login">Entrada de dados de login</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            Usuario usuarioEncontrado = _usuarioRepository.Login(login.Email, login.Senha);

            if (usuarioEncontrado == null)
            {
                return Unauthorized(new { msg = "E-mail e/ou senha inválidos" });
            }

            var myClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.UsuarioId.ToString()),
                new Claim(ClaimTypes.Role, usuarioEncontrado.Tipo)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                   issuer: "exoapi.webapi",
                   audience: "exoapi.webapi",
                   claims: myClaims,
                   expires: DateTime.Now.AddMinutes(60),
                   signingCredentials: creds
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}