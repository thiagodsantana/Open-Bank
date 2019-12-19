using OpenBank.Domain.Models;
using OpenBank.Repository.Context;
using OpenBank.Repository.Repositories.Interfaces;

namespace OpenBank.Repository.Repositories.Classes
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(OpenBankContext db) : base(db)
        {

        }
    }
}
