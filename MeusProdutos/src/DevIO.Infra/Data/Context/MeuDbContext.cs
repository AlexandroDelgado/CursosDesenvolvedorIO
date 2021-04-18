using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Context
{
    // O MeuDbContext irá herdar de DbContext para transforma o mesmo no contexto do EntityFramework
    public class MeuDbContext : DbContext
    {
        // O contrutor herda da base a connecition string para conexão com o banco
        public MeuDbContext() : base(nameOrConnectionString: "DefaultConnection")
        {

        }

        // Mapeamento do DbSet Para produtos
        public DbSet<Produto> Produtos { get; set; }

        // Mapeamento do DbSet Para produtos
        public DbSet<Endereco> Enderecos { get; set; }

        // Mapeamento do DbSet Para produtos
        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
