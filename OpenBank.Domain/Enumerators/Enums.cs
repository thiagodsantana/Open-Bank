using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Enumerators
{
    public enum EnumTrasacao
    {
        Deposito = 1,
        Saque = 2,
        Ted = 3,
        Doc = 4       
    }

    public enum EnumTipoConta
    {
        Poupanca = 1,
        Corrente = 2        
    }

    public enum EnumTipoMovimento
    {
        Credito = 1,
        Debito = 2
    }
}
