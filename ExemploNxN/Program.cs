using ExemploNxN.Dados;
using ExemploNxN.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploNxN
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Funções de escrita
            //await AdicionaUsuarios();
            //await AdicionaPerfis();
            //await AdicionaUsuarioComPerfilNovo();
            //await AdicionaUsuarioComPerfilExistente();

            //Funções de leitura
            //await LerUsuariosComPerfil();
        }

        /// <summary>
        /// Função que adiciona usuários ao banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task AdicionaUsuarios()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new NxNContext();

            Console.WriteLine("Adicionando Usuário 1 ao contexto");
            db.Usuarios.Add(new Usuario
            {
                Login = "Usuário 1",
                Senha = "123456"
            });

            Console.WriteLine("Adicionando Usuário 2 ao contexto");
            db.Usuarios.Add(new Usuario
            {
                Login = "Usuário 2",
                Senha = "123456"
            });

            Console.WriteLine("Salvando as alterações do contexto");
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Função que adiciona perfis ao banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task AdicionaPerfis()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new NxNContext();

            Console.WriteLine("Adicionando Administrador ao contexto");
            db.Perfis.Add(new Perfil
            {
                Nome = "Administrador"
            });

            Console.WriteLine("Adicionando Gerente ao contexto");
            db.Perfis.Add(new Perfil
            {
                Nome = "Gerente"
            });

            Console.WriteLine("Salvando as alterações do contexto");
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Função que adiciona usuário com perfil novo ao banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task AdicionaUsuarioComPerfilNovo()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new NxNContext();

            Console.WriteLine("Adicionando Usuário 3 ao contexto");
            db.Usuarios.Add(new Usuario
            {
                Login = "Usuário 3",
                Senha = "123456",
                Perfis = new List<Perfil>
                {
                    new Perfil
                    {
                        Nome = "Usuário"
                    }
                }
            });

            Console.WriteLine("Salvando as alterações do contexto");
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Função que adiciona usuário com perfil existente ao banco de dados
        /// </summary>
        /// <returns></returns>
        static async Task AdicionaUsuarioComPerfilExistente()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new NxNContext();

            Console.WriteLine("Carregando perfil a ser vinculado com o novo usuário");
            var perfilExistente = await db.Perfis.FirstOrDefaultAsync(x => x.Nome == "Administrador");

            Console.WriteLine("Adicionando Usuário 4 ao contexto");
            db.Usuarios.Add(new Usuario
            {
                Login = "Usuário 4",
                Senha = "123456",
                Perfis = new List<Perfil> { perfilExistente }
            });

            Console.WriteLine("Salvando as alterações do contexto");
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Função que faz a leitura de usuários que possuam pelo menos 1 perfil
        /// </summary>
        /// <returns></returns>
        static async Task LerUsuariosComPerfil()
        {
            Console.WriteLine("Instanciando o contexto");
            using var db = new NxNContext();

            Console.WriteLine("Consultando dados...");
            var listaUsuarios = await db.Usuarios
                                            .AsNoTracking()
                                            
                                            .Where(x => x.Perfis.Any())
                                            .ToListAsync();

            Console.WriteLine("Imprimindo dados");
            listaUsuarios.ForEach(x => ImprimirUsuario(x));
        }

        /// <summary>
        /// Função utilizada para imprimir dados de usuário
        /// </summary>
        /// <param name="usuario"></param>
        static void ImprimirUsuario(Usuario usuario)
        {
            Console.WriteLine($"{usuario.Login}|{usuario.Senha}|{(usuario.Perfis != null ? usuario.Perfis.Count : "Null")}");
            if (usuario.Perfis != null)
                usuario.Perfis.ToList().ForEach(x => ImprimirPerfil(x));
        }

        /// <summary>
        /// Função utilizada para imprimir dados de perfil
        /// </summary>
        /// <param name="perfil"></param>
        static void ImprimirPerfil(Perfil perfil)
        {
            Console.WriteLine($"-> {perfil.Nome}");
        }
    }
}
