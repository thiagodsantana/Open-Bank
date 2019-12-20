using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class TransacaoVM
    {
        public int TipoMovimento { get; set; }
        public decimal valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
