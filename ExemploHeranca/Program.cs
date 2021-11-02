using ExemploHeranca.Dados;
using ExemploHeranca.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploHeranca
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Funções de escrita
            //await AdicionaPessoasFisicas();
            //await AdicionaPessoasJuridicas();

            //Funções de leitura
            //await LerPessoasFisicas();
            //await LerPessoasJuridicas();
            //await LerPessoas();
        }

        /// <summary>
        /// Função que adiciona pessoa física ao banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task AdicionaPessoasFisicas()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new HerancaContext();

            Console.WriteLine("Adicionando José da Silva ao contexto");
            db.PessoasFisicas.Add(new PessoaFisica
            {
                Nome = "José da Silva",
                CPF = "440.877.460-03"
            });

            Console.WriteLine("Adicionando João Barbosa ao contexto");
            db.PessoasFisicas.Add(new PessoaFisica
            {
                Nome = "João Barbosa",
                CPF = "780.314.800-01"
            });

            Console.WriteLine("Salvando as alterações do contexto");
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Função que adiciona pessoa jurídica ao banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task AdicionaPessoasJuridicas()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new HerancaContext();

            Console.WriteLine("Adicionando Silva Tecnologia Ltda ao contexto");
            db.PessoasJuridicas.Add(new PessoaJuridica
            {
                Nome = "Silva Tecnologia Ltda",
                Cnpj = "31.114.420/0001-22"
            });

            Console.WriteLine("Adicionando Barbosa Alimentos SA ao contexto");
            db.PessoasJuridicas.Add(new PessoaJuridica
            {
                Nome = "Barbosa Alimentos SA",
                Cnpj = "10.784.547/0001-89"
            });

            Console.WriteLine("Salvando as alterações do contexto");
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Função que faz leitura de pessoa física no banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task LerPessoasFisicas()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new HerancaContext();

            Console.WriteLine("Consultando dados...");
            var listaPessoasFisicas = await db.PessoasFisicas.ToListAsync();

            Console.WriteLine("Imprimindo ID|CPF|Nome");
            listaPessoasFisicas.ForEach(x => ImprimirPessoa(x));
        }

        /// <summary>
        /// Função que faz leitura de pessoa jurídica no banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task LerPessoasJuridicas()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new HerancaContext();

            Console.WriteLine("Consultando dados...");
            var listaPessoasJuridicas = await db.PessoasJuridicas.ToListAsync();

            Console.WriteLine("Imprimindo ID|Cnpj|Nome");
            listaPessoasJuridicas.ForEach(x => ImprimirPessoa(x));
        }

        /// <summary>
        /// Função que faz leitura de pessoas no banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task LerPessoas()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new HerancaContext();

            Console.WriteLine("Consultando dados...");
            var listaPessoas = await db.Pessoas.ToListAsync();

            Console.WriteLine("Imprimindo pessoas");
            listaPessoas.ForEach(x => ImprimirPessoa(x));
            
        }

        /// <summary>
        /// Método utilizado para imprimir pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        static void ImprimirPessoa(Pessoa pessoa)
        {
            if (pessoa is PessoaFisica)
                ImprimirPessoaFisica(pessoa as PessoaFisica);
            else
                ImprimirPessoaJuridica(pessoa as PessoaJuridica);
        }

        /// <summary>
        /// Função utilizada para imprimir os dados de pessoa física
        /// </summary>
        /// <param name="pf"></param>
        static void ImprimirPessoaFisica(PessoaFisica pf)
        {
            Console.WriteLine($"{pf.Id}|{pf.CPF}|{pf.Nome}");
        }

        /// <summary>
        /// Função utilizada para imprimir os dados de pessoa jurídica
        /// </summary>
        /// <param name="pj"></param>
        static void ImprimirPessoaJuridica(PessoaJuridica pj)
        {
            Console.WriteLine($"{pj.Id}|{pj.Cnpj}|{pj.Nome}");
        }
    }
}
