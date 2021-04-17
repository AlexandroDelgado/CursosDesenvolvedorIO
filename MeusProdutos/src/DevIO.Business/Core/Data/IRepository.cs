using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevIO.Business.Core.Models;

namespace DevIO.Business.Core.Data
{
    // Essa idéia de uma interface chamada IRepository serve para persistir qualquer entidade, fazendo as regras básicas de persistência.
    // Que seria o CRUD entre umas coisinhas um pouco especializadas.
    // Como não sabemos qual entidade vai ser persistida aqui, trataremos a mesma como uma interface genérica.
    // Só pode ser passada para o IRepository, entidades que herdarem de Entity, ou seja, entidades que são persistidas no banco. 
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity 
    {
        // Todos os métodos, serão trabalhados de forma assincrona.

        // O método recebe uma entidade "entity" por parametro que é do tipo uma entidade genérica "TEntity" e retorna uma Task.
        Task Adicionar(TEntity entity);

        // Retorna uma unica entidade por que é por id. Ou seja: um id, uma entidade.
        Task<TEntity> ObterPorId(Guid id);

        // Retorna uma lista de entidades, está definido como "List" por ser um tipo concreto
        Task<List<TEntity>> ObterTodos();

        // Retorna uma task recebendo um objeto do tipo entidade.
        Task Atualizar(TEntity entity);

        // Retorna uma Task, só que este método está recebendo um id, ao invés de uma entidade.
        Task Remover(Guid id);

        // Retorna um IEnumerable ou seja uma coleção de entidades.
        // Através do método Buscar, que está recebendo uma expressão lâmbida em cima da entidade que estamos trabalhando.
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        // Salva no banco e retorna um inteiro com um numero de produtos persistidos no banco.
        Task<int> SaveChanges();
    }
}
