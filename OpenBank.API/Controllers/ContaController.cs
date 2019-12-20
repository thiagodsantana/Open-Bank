using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenBank.Domain.Models;
using OpenBank.Domain.ViewModels;
using OpenBank.Service.Services.Interfaces;

namespace OpenBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContaController : Controller
    {
        private readonly IContaService _contaService;
        private readonly ITransacaoService _transacaoService;
        private readonly AuthenticatedUser _authenticatedUser;

        public ContaController(AuthenticatedUser authenticatedUser, IContaService contaService, ITransacaoService transacaoService)
        {
            _authenticatedUser = authenticatedUser;
            _contaService = contaService;
            _transacaoService = transacaoService;
        }

        [Route("Sacar")]
        [HttpPost]
        public IActionResult Sacar([FromBody] MovimentoBancarioVM movimento)
        {
            try
            {
                var conta = _contaService.ObterConta(movimento.Agencia, movimento.NumConta);
                if (conta == null)
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Conta não localizada!"
                    });
                }
                if (conta.ClienteId != Convert.ToInt32(_authenticatedUser.Id))
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Dados bancários inválido!"
                    });
                }
                _contaService.Sacar(conta.Id, movimento.Valor);
                return Ok(new
                {
                    Mensagem = "Saque efetuado com sucesso!"
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
        public IActionResult Depositar([FromBody] MovimentoBancarioVM movimento)
        {
            try
            {
                var conta = _contaService.ObterConta(movimento.Agencia, movimento.NumConta);
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
                    Mensagem = "Depósito efetuado com sucesso!"
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

        [Route("Saldo")]
        [HttpPost]
        public IActionResult ObterSaldo([FromBody] DadosContaVM contaVM)
        {
            try
            {
                var conta = _contaService.ObterConta(contaVM.Agencia, contaVM.NumConta);
                if (conta == null)
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Conta não localizada!"
                    });
                }
                if (conta.ClienteId != Convert.ToInt32(_authenticatedUser.Id))
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Dados bancários inválido!"
                    });
                }
                var saldo = _contaService.ObterSaldo(contaVM.Agencia, contaVM.NumConta);
                return Ok(new SaldoVM
                {
                    Conta = Mapper.Map<Conta, DadosContaVM>(conta),
                    Saldo = saldo
                }
                );
            }
            catch (Exception ex)
            {

                return BadRequest(new ErroVM
                {
                    Excecao = ex.Message,
                    Mensagem = "Não foi possível obter o saldo!"
                });
            }
        }

        [Route("Extrato")]
        [HttpPost]
        public IActionResult ObterExtrato([FromBody] ExtratoVM extrato)
        {
            try
            {
                var conta = _contaService.ObterConta(extrato.Agencia, extrato.NumConta);
                if (conta.ClienteId != Convert.ToInt32(_authenticatedUser.Id))
                {
                    return BadRequest(new ErroVM
                    {
                        Excecao = "",
                        Mensagem = "Dados bancários inválido!"
                    });
                }
                var transacoes = _transacaoService.ObterExtrato(conta.Id, Convert.ToDateTime(extrato.PeriodoInicial), Convert.ToDateTime(extrato.PeriodoFinal)).OrderByDescending(p => p.DataHora).ToList();
                var listExtrato = Mapper.Map<List<Transacao>, List<TransacaoVM>>(transacoes);

                return Ok(
                    listExtrato
                );
            }
            catch (Exception ex)
            {

                return BadRequest(new ErroVM
                {
                    Excecao = ex.Message,
                    Mensagem = "Não foi possível obter o saldo!"
                });
            }

        }
    }
}