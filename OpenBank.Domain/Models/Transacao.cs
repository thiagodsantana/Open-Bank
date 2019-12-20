using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public int ContaId { get; set; }
        public int TipoMovimento { get; set; }
        public decimal valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}
