using System.Reflection;
using System.Web.Mvc;
using DevIO.Business.Core.Notifications;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Fornecedores.Services;
using DevIO.Business.Models.Produtos;
using DevIO.Business.Models.Produtos.Services;
using DevIO.Infra.Data.Context;
using DevIO.Infra.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace DevIO.AppMVC.App_Start
{
    public class DependecyInjectionConfig
    {
        // Método statico do Container para injeção de dependência.
        public static void RegisterDIContainer()
        {
            // Definindo o container
            var container = new Container();

            // Definindo o LifeStyle do container
            // (Estamos utilizando o WebRequestLifestyle para trabalhar com a web, mas podemos trabalhar com outros tipos de aplicativo. Consulte a documentação.)
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Inicia a criação do container
            InitializeContainer(container);

            // Registrando as controllers para validar se elas estão configuradas para trabalhar com o SimpleInjector
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // Validando as Controllers
            container.Verify();

            // Passa uma stância do SimpleInjector para o MVC5, já que o mesmo não possui injeção de dependência nativa,
            // mas possui uma classe que consegue trabalhar com suporte a injeção de dependência.
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));


        }

        // Método que recebe a instância do container e configura a criação dos objetos (Repositorio, Serviço, Auto Mapper e etc)
        // Registra todas as que serão injetadas, via injeção de dependência.
        private static void InitializeContainer(Container container)
        {
            // Lifestyle significa como o objeto é criado e quanto tempo ele dura. Existe 3 tipos de Lifestyle populares.
            // Lifestyle.Singleton que define uma instância por aplicação. (Nunca utilizar para objetos que trabalhe com banco)
            // Lifestyle.Transient que cria uma nova instância para cada injeção.
            // Lifestyle.Scoped que é uma unica instância por request e só funciona para aplicação web

            // Registra a criação de uma instância de produto Repository
            // onde a interface é "IProdutoRepository" e a instância a ser criada será "ProdutoRepository";
            // Registrar todas as instâncias e objetos depentendes, ou seja, o que estiver dentro do construtor para injeção, deve ser registrado.
            container.Register<MeuDbContext>(Lifestyle.Scoped); // Não possui uma interface
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            // Este irá criar uma instância unica que é atribuida pelo AutoMapper através de um delegate
            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));

        }


    }
}