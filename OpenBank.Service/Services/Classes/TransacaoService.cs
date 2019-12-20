using OpenBank.Domain.Models;
using OpenBank.Repository.Repositories.Interfaces;
using OpenBank.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenBank.Service.Services.Classes
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository _transacaoRepository;

        public TransacaoService(ITransacaoRepository transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
        }

        public List<Transacao> ObterExtrato(int idConta, DateTime periodoInicial, DateTime periodoFinal)
        {
            if (periodoInicial > periodoFinal)
                throw new Exception("A Data inicial não pode ser maior que a Data Final");

           return _transacaoRepository.FindBy(p => p.ContaId == idConta && p.DataHora.Date >= periodoInicial && p.DataHora.Date <= periodoFinal).ToList();            
        }        
    }
}
