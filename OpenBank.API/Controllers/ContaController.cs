using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.ViewModels;
using OpenBank.Service.Services.Interfaces;

namespace OpenBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        private readonly IContaService _contaService;
        private readonly AuthenticatedUser _authenticatedUser;

        public ContaController(AuthenticatedUser authenticatedUser, IContaService contaService)
        {
            _authenticatedUser = authenticatedUser;
            _contaService = contaService;
        }

        [Route("Sacar")]
        [HttpPost]
        public IActionResult Sacar([FromBody] MovimentoVM movimento)
        {
            try
            {
                var conta = _contaService.ObterContaId(movimento.Agencia, movimento.Conta);
                if (conta.ClienteId !=  Convert.ToInt32(_authenticatedUser.Id))
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Dados bancários inválido!"
                    });
                }

                if (conta == null)
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Conta não localizada!"
                    });
                }
                _contaService.Sacar(conta.Id, movimento.Valor);
                return Ok(new
                {

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErroVM
                {
                    Excecao = ex.Message,
                    Mensagem = "Não foi possível efetuar o saque!"
                });
            }            
        }

        [Route("Depositar")]
        [HttpPost]
        public IActionResult Depositar([FromBody] MovimentoVM movimento)
        {
            try
            {
                var conta = _contaService.ObterContaId(movimento.Agencia, movimento.Conta);
                if (conta == null)
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Conta não localizada!"
                    });
                }
                _contaService.Depositar(conta.Id, movimento.Valor);
                return Ok(new
                {

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErroVM
                {
                    Excecao = ex.Message,
                    Mensagem = "Não foi possível efetuar o depósito!"
                });
            }
        }

        [Route("ExtratoBancario")]
        [HttpPost]
        public IActionResult ObterExtrato([FromBody] MovimentoVM movimento)
        {
            return BadRequest();
        }
    }
}