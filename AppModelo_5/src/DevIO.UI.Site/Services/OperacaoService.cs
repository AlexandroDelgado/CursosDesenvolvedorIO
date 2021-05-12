using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Services
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Está classe Operação, está implementando 4 tipos de interface
    // (Na verdade são o mesmo tipo de interface, criadas de forma repetitiva para a
    //  declaração de injeção de dependência de cada uma delas de forma diferente)
    public class Operacao : IOperacaoTransient,
                            IOperacaoScoped,
                            IOperacaoSingleton,
                            IOperacaoSingletonInstance
    {
        // Define uma propriedade do tipo Guid
        public Guid OperacaoId { get; private set; }

        // 
        public Operacao() : this(Guid.NewGuid())
        {
        }

        // Construtor que popula a propriedade do tipo Guid
        public Operacao(Guid id)
        {
            OperacaoId = id;
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //
    public class OperacaoService
    {
        // 
        public IOperacaoTransient Transient { get; }
        public IOperacaoScoped Scoped { get; }
        public IOperacaoSingleton Singleton { get; }
        public IOperacaoSingletonInstance SingletonInstance { get; }

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
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 
    public interface IOperacao
    {
        Guid OperacaoID { get; }
    }

    // 
    public interface IOperacaoTransient : IOperacao
    { }

    // 
    public interface IOperacaoScoped : IOperacao
    { }

    // 
    public interface IOperacaoSingleton : IOperacao
    { }

    // 
    public interface IOperacaoSingletonInstance : IOperacao
    { }
}
