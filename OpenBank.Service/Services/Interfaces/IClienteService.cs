using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Service.Services.Interfaces
{
    public interface IClienteService
    {
        Cliente ObterPorCpf(string cpf);
    }
}
