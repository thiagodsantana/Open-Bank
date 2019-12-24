using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class Conta
    {
        [Display(Name = "Identificador da Conta")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Identificador do Cliente' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Identificador do Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo 'Agência' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Agência")]
        [StringLength(6)]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "O campo 'Número da Conta' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Número da Conta")]
        [StringLength(10)]
        public string NumConta { get; set; }

        [Required(ErrorMessage = "O campo 'Saldo Atual' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Saldo")]
        public decimal Saldo { get; set; }

        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual List<Transacao> Transacoes { get; set; }
    }
}
