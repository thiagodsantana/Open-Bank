using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Service.Services.Interfaces
{
    public interface ITransacaoService
    {
        List<Transacao> ObterExtrato(int idConta, DateTime periodoInicial, DateTime periodoFinal);
    }
}
