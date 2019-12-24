using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class Transacao
    {
        [Display(Name = "Identificador Transação")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Identificador da Conta' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Identificador da Conta")]
        public int ContaId { get; set; }

        [Required(ErrorMessage = "O campo 'Tipo do Movimento' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Tipo do Movimento")]
        public int TipoMovimento { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Valor")]
        [DisplayFormat(DataFormatString = "{0,c}")]
        public decimal valor { get; set; }

        [Required(ErrorMessage = "O campo 'Data/Hora' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Data/Hora")]
        public DateTime DataHora { get; set; }

        public virtual Conta Conta { get; set; }
    }
}
