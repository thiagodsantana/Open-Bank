using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenBank.DAL;
using OpenBank.DAL.Repositories.Interfaces;
using OpenBank.MOD.Models;
using OpenBank.MOD.ViewModels;

namespace OpenBank.API.Controllers
{
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IClienteRepository _clienteRepository;

        public TokenController(IConfiguration configuration, IClienteRepository clienteRepository)
        {
            _configuration = configuration;
            _clienteRepository = clienteRepository;
        }

        [AllowAnonymous]
        [HttpPost("RequestToken")]
        [HttpPost]
        public IActionResult RequestToken([FromBody] LoginVM request)
        {

            var cliente = _clienteRepository.FindBy(p => p.Cpf.Equals(request.Cpf)).FirstOrDefault();
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

        protected string GerarToken(LoginVM request)
        {

            var claims = new Claim[2];          
            var cliente = _clienteRepository.FindBy(p => p.Cpf.Equals(request.Cpf)).FirstOrDefault();
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