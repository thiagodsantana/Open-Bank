using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OpenBank.Domain.Models
{
    public class Cliente
    {
        [Display(Name = "Identificador do Cliente")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'CPF' é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(11, MinimumLength = 11)]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.", AllowEmptyStrings = false)]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo 'SobreNome' obrigatório.", AllowEmptyStrings = false)]
        [StringLength(150)]
        [Display(Name = "SobreNome")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' é obrigatório.", AllowEmptyStrings = false)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [StringLength(50)]
        public string Senha { get; set; }

        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        public virtual List<Conta> Contas { get; set; }
    }
}
