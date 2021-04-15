using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteMVC5.Models;

namespace TesteMVC5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {
            // Clique com o botão direito do mouse sobre o progeto e vá em Gerenciar pacotes do Nuget, instale a versão mais recente do EntityFramework.
            // Vá até o Web.Config e coloque a string de conexão com o banco de dados.
            // <add name="DefaultConnection" connectionString="Data Source=ALEDESKTOP;AttachDbFilename=|DataDirectory|\AppTesteMvc5.mdf;Initial Catalog=AppTesteMvc5;Integrated Security=True" providerName="System.Data.SqlClient" />
            // Depois abra o console do gerenciador de pacotes do Visual Studio digite "enable-migrations" e aperte enter, dê acesso a
            // "Todos(verificar qual o usuário necessário)", em seguida digite no console do gerenciador de pacotes "update-database -verbose -Script" e aperte enter.

        }

        // Cria o objeto dataset com base na model.
        public DbSet<Aluno> Alunos { get; set; }

        // O método abaixo remove a pluralização do sql server e utiliza a referências acima para a criação da tabela.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Não deixa o visual studio pluralizar as tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // informa ao entity para utilizar o nome da tabela no plural, do jeito que foi escrito.
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}