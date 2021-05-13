using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Servicos
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Classe que recebe uma injeção de dependência de cada tipo da operação
    public class OperacaoService
    {
        // Recebe uma injeção de dependência de cada um dos 4 tipos de instâncias da classe operação, usando cada um dos ciclos de vida disponíveis
        public OperacaoService(
            IOperacaoTransient transient,
            IOperacaoScoped scoped,
            IOperacaoSingleton singleton,
            IOperacaoSingletonInstance singletonInstance)
        {
            Transient = transient;
            Scoped = scoped;
            Singleton = singleton;
            SingletonInstance = singletonInstance;
        }

        // Define uma propriedade para cada tipo de operação.
        public IOperacaoTransient Transient { get; }
        public IOperacaoScoped Scoped { get; }
        public IOperacaoSingleton Singleton { get; }
        public IOperacaoSingletonInstance SingletonInstance { get; }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Está classe Operação, está implementando 4 tipos de interface
    // (Na verdade são o mesmo tipo de interface, criadas de forma repetitiva para a
    //  declaração de injeção de dependência de cada uma delas de forma diferente)
    public class Operacao : IOperacaoTransient,
                            IOperacaoScoped,
                            IOperacaoSingleton,
                            IOperacaoSingletonInstance
    {
        // 
        public Operacao() : this(Guid.NewGuid())
        {
        }

        // Construtor que popula a propriedade do tipo Guid
        public Operacao(Guid id)
        {
            OperacaoId = id;
        }

        // Define uma propriedade chamada OperaçãoID do tipo Guid, que é implementada pelas interfaces.
        // Já que todas as 4 interfaces implementam o Id, bastaria chamar uma única vez, porém sou obrigado
        //    a declarar este id.
        public Guid OperacaoId { get; private set; }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Implementa a interface de Operação
    public interface IOperacao
    {
        // Implementa o ID
        Guid OperacaoId { get; }
    }

    // Interface de operação, que implementam uma única interface chamada IOperação.
    public interface IOperacaoTransient : IOperacao
    {
    }

    // Interface de operação, que implementam uma única interface chamada IOperação.
    public interface IOperacaoScoped : IOperacao
    {
    }

    // Interface de operação, que implementam uma única interface chamada IOperação.
    public interface IOperacaoSingleton : IOperacao
    {
    }

    // Interface de operação, que implementam uma única interface chamada IOperação.
    public interface IOperacaoSingletonInstance : IOperacao
    {
    }
}
