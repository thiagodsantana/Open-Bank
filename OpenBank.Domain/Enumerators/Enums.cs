using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OpenBank.Domain.Enumerators
{
    public enum EnumTrasacao
    {
        [Description("Depósito")]
        Deposito = 1,
        [Description("Saque")]
        Saque = 2,
        [Description("TED")]
        Ted = 3,
        [Description("DOC")]
        Doc = 4       
    }

    public enum EnumTipoConta
    {
        [Description("Poupança")]
        Poupanca = 1,
        [Description("Conta Corrente")]
        Corrente = 2        
    }

    public enum EnumTipoMovimento
    {
        [Description("Crédito")]
        Credito = 1,
        [Description("Débito")]
        Debito = 2
    }
}
