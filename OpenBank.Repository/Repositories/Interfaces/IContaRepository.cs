using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Repository.Repositories.Interfaces
{
    public interface IContaRepository : IRepository<Conta>
    {
        bool Sacar(int idConta);
        bool Depositar(int idConta);
        void ObterExtrato(int idConta);
    }
}
