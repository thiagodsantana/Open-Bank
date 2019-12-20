using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Service.Services.Interfaces
{
    public interface IContaService
    {
        Conta ObterContaId(string agencia, string numConta);
        bool Depositar(int idConta, decimal valor);
        bool Sacar(int idConta, decimal valor);

    }
}
