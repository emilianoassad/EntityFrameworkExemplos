using ExemploNxN.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploNxN.Dados
{
    public class NxNContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQL2017;Database=teste-n-n;User ID=teste;Password=senhateste;Trusted_Connection=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mapeia o relacionamento NxN definindo o nome da tabela a ser gerada
            modelBuilder
                    .Entity<Usuario>()
                    .HasMany(x => x.Perfis)
                    .WithMany(x => x.Usuarios)
                    .UsingEntity(x => x.ToTable("UsuarioPerfil"));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Perfil> Perfis { get; set; }
    }
}
