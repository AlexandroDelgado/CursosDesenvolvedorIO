using System.Data.Entity;
using TesteMVC5.Models;

namespace TesteMVC5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {
                
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}