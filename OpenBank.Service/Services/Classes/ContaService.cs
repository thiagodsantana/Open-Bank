using OpenBank.Domain.Enumerators;
using OpenBank.Domain.Models;
using OpenBank.Repository.Repositories.Interfaces;
using OpenBank.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace OpenBank.Service.Services.Classes
{
    public class ContaService : IContaService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IContaRepository _contaRepository;
        private readonly ITransacaoRepository _transacaoRepository;

        public ContaService(IClienteRepository clienteRepository, IContaRepository contaRepository, ITransacaoRepository transacaoRepository)
        {
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
            _transacaoRepository = transacaoRepository;
        }
        
        public Conta ObterConta(string agencia, string numConta)
        {
            return _contaRepository.FindBy(p => p.Agencia.Equals(agencia) && p.NumConta.Equals(numConta)).FirstOrDefault();
        }

        public bool Depositar(int idConta, decimal valor)
        {
            try
            {
                var conta = _contaRepository.FindBy(p => p.Id == idConta).FirstOrDefault();
                if (conta == null)
                {
                    throw new Exception("Conta não localizada!");
                }
                using (TransactionScope ts = new TransactionScope())
                {
                    conta.Saldo += valor;
                    _contaRepository.Update(conta);

                    _transacaoRepository.Add(new Transacao
                    {
                        ContaId = conta.Id,
                        DataHora = DateTime.Now,
                        TipoMovimento = (int)EnumTrasacao.Deposito,
                        valor = valor
                    });
                    ts.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public decimal ObterSaldo(string agencia, string numConta)
        {            
            var conta = _contaRepository.FindBy(p => p.Agencia.Equals(agencia) && p.NumConta.Equals(numConta)).FirstOrDefault();
            if (conta == null)
            {
                throw new Exception("Conta não localizada!");
            }
            return conta.Saldo;
        }

        public bool Sacar(int idConta, decimal valor)
        {
            try
            {
                var conta = _contaRepository.FindBy(p => p.Id == idConta).FirstOrDefault();
                if (conta == null)
                {
                    throw new Exception("Conta não localizada!");
                }
                if (conta.Saldo < valor)
                {
                    throw new Exception("Saldo insuficiente!");
                }

                using (TransactionScope ts = new TransactionScope())
                {
                    conta.Saldo -= valor;
                    _contaRepository.Update(conta);

                    _transacaoRepository.Add(new Transacao
                    {
                        ContaId = conta.Id,
                        DataHora = DateTime.Now,
                        TipoMovimento = (int)EnumTrasacao.Saque,
                        valor = valor
                    });
                    ts.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
