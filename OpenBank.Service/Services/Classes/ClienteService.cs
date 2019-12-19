using OpenBank.Domain.Models;
using OpenBank.Repository.Repositories.Interfaces;
using OpenBank.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenBank.Service.Services.Classes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.FindBy(p => p.Cpf.Equals(cpf)).FirstOrDefault();            
        }
    }
}
