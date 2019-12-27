using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Service.Services.Interfaces
{
    public interface IContaService
    {        
        Conta ObterConta(int idUser, string agencia, string numConta);
        decimal ObterSaldo(string agencia, string NumConta);
        bool Depositar(int idConta, decimal valor);
        bool Sacar(int idConta, decimal valor);

    }
}
