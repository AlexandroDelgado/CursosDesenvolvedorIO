using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AppMvc.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Observe que o authenticationType deve corresponder àquele definido em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Adicionar declarações de usuário personalizado aqui
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Cria os objetos data set baseados nas models.
        public DbSet<Aluno> Alunos { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Trata as convenções de linguagem pluralizada
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Não permite que o Visual Studio pluralize as tabelas.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Informa ao Entity Framework para utilizar o nome da tabela no plural.
            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            // Cria o modelo solicitado
            base.OnModelCreating(modelBuilder);
        }
    }
}