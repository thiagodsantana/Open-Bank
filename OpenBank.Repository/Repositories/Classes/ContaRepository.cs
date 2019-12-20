using OpenBank.Domain.Models;
using OpenBank.Repository.Context;
using OpenBank.Repository.Repositories.Interfaces;
using System.Linq;

namespace OpenBank.Repository.Repositories.Classes
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(OpenBankContext db) : base(db)
        {

        }

        public bool Depositar(int idConta, decimal valor)
        {
            try
            {
                if (valor > 0)
                {
                    var conta = FindBy(p => p.Id == idConta).FirstOrDefault();
                    conta.Saldo += valor;
                    Update(conta);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }            
        }

        public void ObterExtrato(int idConta)
        {
            throw new System.NotImplementedException();
        }

        public bool Sacar(int idConta, decimal valor)
        {
            try
            {
                var conta = FindBy(p => p.Id == idConta).FirstOrDefault();
                if (conta.Saldo >= valor)
                {
                    conta.Saldo -= valor;
                    Update(conta);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
