using OpenBank.Domain.Models;
using OpenBank.Repository.Context;
using OpenBank.Repository.Repositories.Interfaces;

namespace OpenBank.Repository.Repositories.Classes
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OpenBankContext db) : base(db)
        {

        }
    }
}
