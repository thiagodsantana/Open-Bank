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
        #region Interfaces
        private readonly IClienteRepository _clienteRepository;
        #endregion

        #region Construtor
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        #endregion

        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);            
        }
    }
}
