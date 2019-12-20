using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class SaldoVM
    {
        public DadosContaVM Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
