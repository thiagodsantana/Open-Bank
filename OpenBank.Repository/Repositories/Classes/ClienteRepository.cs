using OpenBank.Domain.Models;
using OpenBank.Repository.Context;
using OpenBank.Repository.Repositories.Interfaces;
using System.Linq;

namespace OpenBank.Repository.Repositories.Classes
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OpenBankContext db) : base(db)
        {

        }

        public Cliente ObterPorCpf(string cpf)
        {
           return FindBy(p => p.Cpf.Equals(cpf)).FirstOrDefault();
        }
    }
}
