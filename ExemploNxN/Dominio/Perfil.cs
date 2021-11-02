using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNxN.Dominio
{
    [Table("Perfil")]
    public class Perfil
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public IList<Usuario> Usuarios { get; set; }
    }
}
