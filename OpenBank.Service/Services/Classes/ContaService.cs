﻿using Microsoft.EntityFrameworkCore;
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
        #region Interfaces
        private readonly IContaRepository _contaRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        #endregion

        #region Construtor
        public ContaService(IContaRepository contaRepository, ITransacaoRepository transacaoRepository)
        {
            _contaRepository = contaRepository;
            _transacaoRepository = transacaoRepository;
        }
        #endregion

        public Conta ObterConta(int idUser, string agencia, string numConta)
        {
            var conta = _contaRepository.FindBy(p => p.Agencia.Equals(agencia) && p.NumConta.Equals(numConta)).Include(p => p.Cliente).FirstOrDefault();
            if (conta == null)
                throw new Exception("Conta não localizada!");

            if (conta.ClienteId != idUser)
                throw new Exception("Dados bancários inválidos!");
            return conta;
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
