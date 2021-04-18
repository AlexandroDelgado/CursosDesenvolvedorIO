using DevIO.Business.Core.Data;
using DevIO.Business.Core.Models;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    // Essa classe genérica vai executar tudo que está implementado na classe: "DevIO.Business\Core\Data\IRepository.cs"
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() // A classe Repository precisa ser genérica devido a mesma implementar a classe Irepository<> que é generica. Nota, o nome TEntity é defino pelo usuário, pode ser qualquer outro.
    {
        // Cria um acesso ao contexto e ao DbSet
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        // Construtor protegido
        protected Repository()
        {
            // Recebe uma nova instância do contexto geral
            Db = new MeuDbContext();

            // Atalho para a entidade
            DbSet = Db.Set<TEntity>();
        }

        // Método que retorna uma entidade
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            // Consulta o contexto por id, encontra a entidade pela chave primária
            return await DbSet.FindAsync(id); // Toda vez que utilizar o método async, deve ser o FindAsync ao invés do Find.
        }

        // Método que retorna uma lista
        public virtual async Task<List<TEntity>> ObterTodos()
        {
            // Retorna a lista de forma assincrona 
            return await DbSet.ToListAsync();
        }

        // Método que implementa uma expressão com busca através de critérios
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) // Não é virtual, pois não precisa ser reescrito
        {
            // Retorna uma lista não persistente
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync(); // .AsNoTracking() impede que o Link, fique sendo persistente, observando a consulta para ver se ela mudou, não será necessário.
        }

        // Método que irá adicionar ao contexto
        public virtual async Task Adicionar(TEntity entity)
        {
            // Adiciona a entidade
            DbSet.Add(entity);

            // não está salvando de forma assincrona
            await SaveChanges();
        }

        // Método que atualiza uma entidade
        public virtual async Task Atualizar(TEntity entity)
        {
            // Altera o status da entidade para modificado, para que ele entenda que não é para adcionar e sim atualizar
            Db.Entry(entity).State = EntityState.Modified;

            // não está salvando de forma assincrona
            await SaveChanges();
        }

        // Remove uma entidade genérica
        public virtual async Task Remover(Guid id)
        {
            // Vai ao banco, busca a entidade e pede para remover
            //DbSet.Remove(await DbSet.FindAsync(id)); // não é a melhor forma, pois estamos trabalhando com entidades genéricas, e todas as entidades genéricas possuem um id.
            //DbSet.Remove(new TEntity { Id = id }); //remove da entidade genérica. Você necessita fazer um new() na assinatura da classe, porém não vai funcionar já que é necessário resgatar a entidade para poder excluir.
            
            // atacha a entidade do id genérico sem precisar ir ao banco
            Db.Entry(new TEntity { Id = id }).State = EntityState.Deleted; // mesmo contexto do atualizar, porém simplesmente passsamos a idéia de qual é a entidade exe: "new TEntity { Id = id }" ao invés da entidade em si.

            // não está salvando de forma assincrona
            await SaveChanges();
        }

        // Método que salva todos os métodos(Delegando responsabilidades)
        public async Task<int> SaveChanges()
        {
            // Salva os métodos de forma assincrona.
            return await Db.SaveChangesAsync(); // Pode ser adicionado o Try Catch aqui.
        }

        // Método que limpa a memória
        public void Dispose()
        {
            // Limpa a memória
            Db?.Dispose(); // O ? ó chama o método se tiver uma instância definida, para evitar o null reference exception.
        }
    }
}
