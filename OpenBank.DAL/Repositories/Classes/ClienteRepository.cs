using OpenBank.DAL.Context;
using OpenBank.DAL.Repositories.Interfaces;
using OpenBank.MOD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.DAL.Repositories.Classes
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OpenBankContext db) : base(db)
        {

        }
    }
}
