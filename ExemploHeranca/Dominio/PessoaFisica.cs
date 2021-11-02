using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHeranca.Dominio
{
    [Table("PessoaFisica")]
    public class PessoaFisica : Pessoa
    {
        [Required]
        [StringLength(14)]
        public string CPF { get; set; }
    }
}
