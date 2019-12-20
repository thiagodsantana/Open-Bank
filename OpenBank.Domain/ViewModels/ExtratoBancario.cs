using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.ViewModels
{
    public class ExtratoBancario
    {
        public ClienteVM DadosCliente { get; set; }
        public ContaVM DadosBancarios { get; set; }        
        public List<Transacao> Transacoes { get; set; }
    }
}
