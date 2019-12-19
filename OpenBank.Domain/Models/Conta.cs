using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Agencia { get; set; }
        public string NumConta { get; set; }
        public decimal Saldo { get; set; }
        public int Tipo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
