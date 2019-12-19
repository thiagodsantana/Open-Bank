using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }     
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
