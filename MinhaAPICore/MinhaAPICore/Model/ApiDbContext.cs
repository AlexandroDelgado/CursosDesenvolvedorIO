using Microsoft.EntityFrameworkCore;

namespace MinhaAPICore.Model
{
    public class ApiDbContext : DbContext
    {
        // Construtor com a passagem das options, onde a classe base irá receber as options conforme a boa prática com o entity framework.
        public ApiDbContext(DbContextOptions options) : base(options)
        {

        }

        // Cria um contexto de fornecedores
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}