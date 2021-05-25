using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MinhaAPICore.Controllers
{
    //// Convenção que passa a decoração da action com os tipos de retorno, necessários para facilitar a documentação do client (Boa Pratica).
    //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions))] // Sem o verbo e neste lugar, não é necessário coloca-lo, em cima dos métodos, ele já passará para toda a controller.
    // Caso queira fazer essa boa prática para toda a aplicação, vá até a "Startup.cs" e coloque o código "[assembly: ApiConventionType(typeof(DefaultApiConventions))]" em cima do namespace.

    [Route("api/[controller]")] // Rota
    //[ApiController] // implementação do atributo da API Controller. Complementa o que é oferecido pela controller.
    //public class ValuesController : ControllerBase
    public class ValuesController : MainController
    {
        // GET api/values
        [HttpGet] // Verbo / Exibir Todos
        public ActionResult<IEnumerable<string>> ObterTodos() // ActionResult Tipado, melhor prática. Pode devolver results(200, 400) ou um tipo.
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return BadRequest(); // Devolve um resultado 400, que quer dizer que o servidor não pode ou não irá processar a sua solictação

            return valores; // Retorna um tipo
        }

        // GET api/values
        [HttpGet] // Verbo / Exibir Todos
        public ActionResult ObterResultado() // ActionResult não tipado. Só pode devolver results.
        {
            var valores = new string[] { "value1", "value2" };

            //if (valores.Length < 5000)
            //    return BadRequest(); // Devolve um resultado 400.

            //return Ok(valores); // OK(), retorna 200.

            // Utilizando o CustomResponse para diminuir código
            if (valores.Length < 5000)
                return CustomResponse(); // houve erro

            return CustomResponse(valores); // não houve erros
        }

        // GET api/values
        [HttpGet("obter-valores")] // Verbo / Exibir Todos
        public IEnumerable<string> ObterValores() // ActionResult tipado direto. Só pode devolver o tipo e nunca um result.
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return null; // Só pode devolver o tipo ou null

            return valores; // Só pode devolver o tipo.
        }

        // GET api/values/5
        [HttpGet("obter-por-id/{id:int}")] // Verbo / Exibir por ID
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost] // Verbo / Gravar
        // Decora a action com os tipos de retorno para facilitar a documentação do client (Boa Pratica).
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)] // Adicionado pelo Analyzers
        [ProducesDefaultResponseType] // Adicionado pelo Analyzers. ProducesDefaultResponseType serve para quando mais de um tipo de erro, possa retornar o mesmo response, ou seja, generaliza os erros, não é necessário ser utilizado, apenas em grandes api.

        //// Caso queira diminuir o código acima, você pode trocar o mesmo abaixo do post pelo código abaixo:
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))] // Não esqueça de utilizar o verbo correto no final.

        public ActionResult Post(Product product)
        {
            if (product.Id == 0) return BadRequest(); // Devolve um resultado 400.

            // Adiciona no banco

            //return Ok(product); // OK(), retorna 200, com o tipo(entidade).
            //return CreatedAtAction(actionName: "Post", product); // CreatedAtAction retorna um código 201, com o objeto serelizado dentro do mesmo. Pode colocar o nome direto "Post".
            //return CreatedAtAction(actionName: nameof(Post), product); // CreatedAtAction retorna um código 201, com o objeto serelizado dentro do mesmo. Pode solictar ao VS que adicione o nome: nameof(Post).

            // Ao utilizar o pacote nuget "Analyzers" ele irá reclamar de que não implementei o retorno do ok(200) em cima do método.
            // Então passe o mouse sobre a reclamação, clique para expandir a lâmpada e clique em "Add ProducesResponseType Attributtes.
            return Ok(product); // OK(), retorna 200, com o tipo(entidade).
        }

        // Convenção que passa a decoração da action com os tipos de retorno, necessários para facilitar a documentação do client (Boa Pratica).
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))] // Não esqueça de utilizar o verbo correto no final.
        // PUT api/values/5
        [HttpPut("{id}")] // Verbo / Alterar
        public ActionResult Put([FromRoute] int id, [FromForm] Product product) 
        {
            // FromRoute: Não necessário quando você possui a impletmentação do api 2.1 e está utilizando a api controller, já que o mesmo está implicito com o uso do ID.
            // FromForm: Quando você recebe os dados de um formulário que envia um content-type do tipo: form-data.
            // FromQuery: Quando você não tem a rota descrita que você recebe um id, mas você quer receber um ID.

            // Caso o status da modelo for inválido, retorna erro 400;
            if (!ModelState.IsValid) return BadRequest();

            if (id != product.Id) return NotFound(); // 404 status não declarado

            // adiciona no banco

            return NoContent(); // não pode passar conteúdo algum
        }

        // DELETE api/values/5
        [HttpDelete("{id}")] // Verbo / Excluir
        public void Delete([FromQuery] int id)
        {
        }
    }

    // Cria uma classe mãe abstrata para diminuir o código
    [ApiController] // implementação do atributo da API Controller. Complementa o que é oferecido pela controller.
    public abstract class MainController : ControllerBase // que está herdando a controller base
    {
        // cria um action result customizado (protected, devido o nivel ser de abstração, ou seja, só quem herda pode utilizar)
        protected ActionResult CustomResponse(object result = null) // recebe um object, que pode ser passado ou não
        {
            // baseia-se em uma condição da qual sempre irá utilizar em uma cituação que tenha modificação de estado, ou seja, inclusão, alteração e exclusão.
            if (OperacaoValida()) // Verifica se foi uma operação válida.
            {
                return Ok(value: new // cria um objeto anônimo.
                {
                    sucess = true, 
                    data = result
                }); ;
            }

            return BadRequest(error: new // cria um objeto anônimo.
            {
                sucess = false,
                errors = ObterErros()
            }); // Devolve um resultado 400, que quer dizer que o servidor não pode ou não irá processar a sua solictação
        }

        public bool OperacaoValida()
        {
            // será feita validações para retornar verdadeiro ou falso
            return true;
        }

        // simulando a obtenção de erros
        protected string ObterErros()
        {
            return "";
        }

    }

    // Cria a classe produto
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
