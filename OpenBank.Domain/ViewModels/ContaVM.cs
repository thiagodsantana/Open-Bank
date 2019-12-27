using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class ContaVM
    {
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public decimal Saldo { get; set; }        
    }
}
