using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class ExtratoBancarioVM
    {
        public ClienteVM Cliente { get; set; }
        public ContaVM Conta { get; set; }
        public List<TransacaoVM> Extrato { get; set; }
    }
}
