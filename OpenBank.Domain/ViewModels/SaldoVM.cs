using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class SaldoVM
    {
        public ClienteVM Cliente { get; set; }
        public DadosContaVM Conta { get; set; }
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal Saldo { get; set; }
    }
}
