using BibliotecaAspNetMvc5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BibliotecaAspNetMvc5.Data
{
    // A classe AppDbContext tem que herdar à DbContext
    public class AppDbContext : DbContext
    {
        // O construtor do método AppDbContext, herda a connection script que recebeu o nome de: DefaultConnection
        public AppDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {
            // Clique com o botão direito do mouse sobre o progeto e vá em Gerenciar pacotes do Nuget, instale a versão mais recente do EntityFramework.
            // Vá até o Web.Config e coloque a string de conexão com o banco de dados.
            // <add name="DefaultConnection" connectionString="Data Source=ALEDESKTOP;AttachDbFilename=|DataDirectory|\AppTesteMvc5.mdf;Initial Catalog=AppTesteMvc5;Integrated Security=True" providerName="System.Data.SqlClient" />
            // Depois abra o console do gerenciador de pacotes do Visual Studio digite "enable-migrations" e aperte enter,
            // acesse o arquivo "Migrations\Configuration" criado no seu gerenciador de soluções, limpe as referencias sujas e
            // altere "AutomaticMigrationsEnable = true, dê acesso à "Todos(verificar qual o usuário necessário)",
            // em seguida digite no console do gerenciador de pacotes "update-database -verbose" caso queira fazer a própria
            // base adicione " -Script" após o verbose, e aperte enter.

        }

        // Cria o objeto datase baseado na model.
        public DbSet<Aluno> Alunos { get; set; }

        // O método abaixo remove a pluralização do sql server.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Não permite o visual studio pluralizar as tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // informa ao entity para utilizar o nome da tabela no plura, do jeito que foi escrito.
            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            base.OnModelCreating(modelBuilder);
        }
    }
}