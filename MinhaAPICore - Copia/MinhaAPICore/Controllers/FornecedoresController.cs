using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAPICore.Model;

namespace MinhaAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        // cria um objeto contexto
        private readonly ApiDbContext _context;

        // injeta o contexo via construtor, fazendo a inversão de dependência.
        public FornecedoresController(ApiDbContext context)
        {
            // seta o contexto
            _context = context;
        }

        // GET: api/Fornecedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores() // Temos uma task devido a utilização de métodos assíncros com uma ActionResult que retorna um IEnumerable do fornecedor.
        {
            return await _context.Fornecedores.ToListAsync(); // Temos o retorno assincrono da ToLinsAsync, já que o entity framework por padrão retorna assyncrono.
        }

        // GET: api/Fornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(Guid id) // Temos o método GetFornecedor passando um Guid e retornando uma task com actionResult, com a entidade fornecedor
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id); // Busca o fornecedor por id, de forma assincrona.

            if (fornecedor == null) // Verifica se o fornecedor existe.
            {
                return NotFound(); // Caso o fornecedor não exista ele retorna NotFound();
            }

            return fornecedor; // Retorna a entidade fornecedor.
        }

        // PUT: api/Fornecedores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(Guid id, Fornecedor fornecedor) // Combinou o nome do verbo com o nome da entidade. Retorna uma interface de ActionResult, a partir do recebimento do id e da entidade fornecedor
        {
            if (id != fornecedor.Id) // Verifica se o id é diferente do id da entidade
            {
                return BadRequest(); // Caso seja diferente retorna um BadRequest
            }

            _context.Entry(fornecedor).State = EntityState.Modified; // Seta o status da entidade no EntityFramework como modificado.

            try // Inicia o tratamento de excessões
            {
                await _context.SaveChangesAsync(); // tenta persistir a entidade
            }
            catch (DbUpdateConcurrencyException)  // Caso tenha ocorrido algum erro de concorrência
            {
                if (!FornecedorExists(id)) // Verifica se o fornecedor existe
                {
                    return NotFound(); // Retorna erro
                }
                else
                {
                    throw; // Caso ele exista, devido ter ocorrido concorrência de excessão. Exemplo, quando outro usuário já exclui e você está tentando atualizar.
                }
            }

            return NoContent(); // Retorna acerto 204.
        }

        // POST: api/Fornecedores
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor) // Retorna um Task de ActionResult com a entidade fornecedor ao receber o a entidade fornecedor
        {
            _context.Fornecedores.Add(fornecedor); // Adiciona a entidade ao contexto fornecedores
            await _context.SaveChangesAsync(); // Persiste o contexto.

            return CreatedAtAction(actionName: "GetFornecedor", routeValues: new { id = fornecedor.Id }, value: fornecedor); // Retorna o nome da api a ser utilizada, passando os valores id e a entidade fornecedor.
        }

        // DELETE: api/Fornecedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Fornecedor>> DeleteFornecedor(Guid id) // Recebe um id Guid e retorna uma Task de ActionResult com a entidade fornecedor.
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id); // Obtem a entidade do fornecedor através do contexto de fornecedores.
            
            if (fornecedor == null) // Verifica se o fornecedor existe
            {
                return NotFound(); // Caso não exista retorna: Não encontrado através do código
            }

            _context.Fornecedores.Remove(fornecedor); // Remove o fornedor do contexto fornecedores.
            await _context.SaveChangesAsync(); // Persiste o contexto.

            return fornecedor; // Retorna a entidade do fornecedor excluido. Pode ser alterado para retornar o códgio 204.
        }

        private bool FornecedorExists(Guid id) // Método privado para verificar se o fornecedor existe. Retorna um boleano sobre a existência ou não do fornecedor.
        {
            return _context.Fornecedores.Any(e => e.Id == id); // Pesquisa o fornecedor no contexto através de seu id.
        }
    }
}
