using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHeranca.Dominio
{
    [Table("PessoaJuridica")]
    public class PessoaJuridica : Pessoa
    {
        [Required]
        [StringLength(18)]
        public string Cnpj { get; set; }
    }
}
