using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class ExtratoVM : DadosContaVM
    {
        public string PeriodoInicial { get; set; }
        public string PeriodoFinal { get; set; }
    }
}
