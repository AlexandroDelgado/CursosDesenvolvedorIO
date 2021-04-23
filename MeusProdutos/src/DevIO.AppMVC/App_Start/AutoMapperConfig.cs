using AutoMapper;
using DevIO.AppMVC.ViewModels;
using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Produtos;
using System;
using System.Linq;
using System.Reflection;

namespace DevIO.AppMVC
{
    // Classe que ativa o AutoMapper
    public class AutoMapperConfig
    {
        // Encontra qualquer classe que herde de Profile do view mapper e faça o mapeamento na inicialização da aplicação

        // Método que irá configurar o mapeamento de acordo com cada instância do profile
        public static MapperConfiguration GetMapperConfiguration()
        {
            // a variavel "profiles" é uma coleção do tipos tipos profile (Isso tudo aqui é um reflection)
            // Captura todos os assemblys que estão sendo executados na inicialização da aplicação
            var profiles = Assembly.GetExecutingAssembly()
                .GetTypes() // Obtem os tipos dos assemblys
                .Where(x => typeof(Profile) // Onde os tipos, são do tipo profile
                .IsAssignableFrom(x)); // onde ela estiver atribuida

            // Retorna uma estância de um contexto de configuração
            return new MapperConfiguration(cfg =>
            {
                // Faz o loop para adicionar o profile
                foreach (var profile in profiles)
                {
                    // Adiciona o profile com base no tipo dele, criando uma estância do tipo profile
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            });
        }
    }

    // Essa classe herda do Profile do Auto mapper 
    public class AutoMapperProfile : Profile
    {
        // Esse construtor é para mapear de um lado para outro
        public AutoMapperProfile()
        {
            // Esse mapeamento é realizado em memória
            // Desde que os campos de um lado seja igual aos campos do outro basta utilizar o "ReverseMap();
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }

    }
}