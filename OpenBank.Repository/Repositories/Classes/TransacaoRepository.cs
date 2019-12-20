using OpenBank.Domain.Models;
using OpenBank.Repository.Context;
using OpenBank.Repository.Repositories.Interfaces;

namespace OpenBank.Repository.Repositories.Classes
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(OpenBankContext db) : base(db)
        {

        }
    }
}
