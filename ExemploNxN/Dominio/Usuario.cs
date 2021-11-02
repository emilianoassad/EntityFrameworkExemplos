using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNxN.Dominio
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(50)]
        public string Senha { get; set; }

        public IList<Perfil> Perfis { get; set; }
    }
}
