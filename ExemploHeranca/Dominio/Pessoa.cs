using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHeranca.Dominio
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Nome { get; set; }
    }
}
