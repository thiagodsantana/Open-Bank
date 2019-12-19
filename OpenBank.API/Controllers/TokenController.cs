using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenBank.Domain.Models;
using OpenBank.Domain.ViewModels;
using OpenBank.Repository;
using OpenBank.Service.Services.Interfaces;

namespace OpenBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IClienteService _clienteService;

        public TokenController(IConfiguration configuration, IClienteService clienteService)
        {
            _configuration = configuration;
            _clienteService = clienteService;
        }
        
        [Route("RequestToken")]
        [HttpPost]
        public IActionResult RequestToken([FromBody] LoginVM request)
        {

            var cliente = _clienteService.ObterPorCpf(request.Cpf);
            if (cliente == null)
            {
                return BadRequest(new ErroVM
                {
                    Excecao = "Usuário não encontrado com o email informado!",
                    Mensagem = "Credenciais inválidas!"
                });
            }

            var hash = new TrataHashGen(SHA1.Create());
            if (hash.VerificarHash(request.Senha, cliente.Senha))
            {
                return Ok(new
                {
                    token = GerarToken(request)
                });
            }
            return BadRequest(new ErroVM
            {
                Excecao = "A senha informada é inválida!",
                Mensagem = "Credenciais inválidas!"
            });

        }        

        private string GerarToken(LoginVM request)
        {

            var claims = new Claim[2];
            var cliente = _clienteService.ObterPorCpf(request.Cpf);
            if (cliente != null)
            {
                claims = new[]
                {
                     new Claim(ClaimTypes.Name, cliente.Id.ToString()),
                     new Claim(ClaimTypes.NameIdentifier, cliente.Nome)
                };
            }
            //recebe uma instancia da classe SymmetricSecurityKey 
            //armazenando a chave de criptografia usada na criação do token
            var key = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                 issuer: "openbank.com",
                 audience: "openbank.com",
                 claims: claims,
                 expires: DateTime.Now.AddDays(1),
                 signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}