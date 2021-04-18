using DevIO.Infra.Data.Context;
using System.Data.Entity.Migrations;

namespace DevIO.Infra.Migrations
{
    // Classe interna selada que herda da classe DbMigrationsConfiguration através do <MeuDbContext>
    internal sealed class Configuration : DbMigrationsConfiguration<MeuDbContext>
    {
        // construtor da classe
        public Configuration()
        {
            // Ativar a migração automática
            AutomaticMigrationsEnabled = true;
        }

    }
}
