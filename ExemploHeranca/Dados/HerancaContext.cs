using ExemploHeranca.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHeranca.Dados
{
    public class HerancaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQL2017;Database=teste-heranca;User ID=teste;Password=senhateste;Trusted_Connection=False;");
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
    }
}
