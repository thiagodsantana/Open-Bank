using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class MovimentoBancarioVM
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public decimal Valor { get; set; }
    }
}
