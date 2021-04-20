using DevIO.Business.Models.Fornecedores;
using DevIO.Business.Models.Fornecedores.Services;
using DevIO.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DevIO.AppMVC.Controllers
{
    // Herda a classe Controller
    public class FornecedoresController : Controller
    {
        //// Declara a interface
        //private readonly IFornecedorService _fornecedorService;

        //// Cria um construtor
        //public FornecedoresController()
        //{
        //    // Instancia o objeto (Não é o jeito certo)
        //    _fornecedorService = new FornecedorService(new FornecedorRepository(), new EnderecoRepository());
        //}

        //// GET: Fornecedores
        //public async Task<ActionResult> Index()
        //{
        //    // Cria uma instância de um fornecedor
        //    var fornecedor = new Fornecedor() {
        //        Nome = "Eduardo fRANGO",
        //        Documento = "30390600822",
        //        Endereco = new Endereco() { 
        //            Logradouro = "Rua das Monsões",
        //            Numero = "315",
        //            Complemento = "fundos",
        //            Bairro = "Jardim Imperador",
        //            Cep = "02568942",
        //            Cidade = "Santo Antonio do Jardim",
        //            Estado = "São Paulo"
        //        },
        //        TipoFornecedor = TipoFornecedor.PessoaFisica,
        //        Ativo = true
        //    };

        //    // Chama o método para persistir
        //    await _fornecedorService.Atualizar(fornecedor);

        //    return new EmptyResult();
        //}
    }
}