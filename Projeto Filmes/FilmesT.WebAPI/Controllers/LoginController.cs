using FilmesT.WebAPI.DTO;
using FilmesT.WebAPI.Interfaces;
using FilmesT.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FilmesT.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpPost]

        public IActionResult Login(LoginDTO loginDTO)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDTO.Email!, loginDTO.Senha!);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou Senha invalida!");
                }

                var Claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Idusuario),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email!),
                };

                //definir a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autentificacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(

                    issuer: "api_filmes",

                    audience: "api_filmes",

                    claims: Claims,

                    expires: DateTime.Now.AddMinutes(5),

                    signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }
    }
}