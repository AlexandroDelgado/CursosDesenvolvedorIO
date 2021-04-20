using DevIO.Business.Core.Models;
using DevIO.Business.Core.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace DevIO.Business.Core.Services
{
    // É uma classe asbrastra, ou seja não pode ser instânciada, apenas herdada
    public abstract class BaseService
    {
        // utiliza a interface notificador
        private readonly INotificador _notificador;

        // Cria o construtor do método
        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        // Adiciona a mensagem alista de notificações
        protected void Notificar(ValidationResult validationResult)
        {
            // Recebe uma lista de erros
            foreach (var error in validationResult.Errors)
            {
                // Chama a sobrecarga
                Notificar(error.ErrorMessage);
            }
        }
        
        // Adiciona a mensagem
        protected void Notificar(string mensagem)
        {
            // A interface chama o método Handle(Adiciona o objeto) passando uma nova instância de notificação recebendo a mensagem
            _notificador.Handle(new Notificacao(mensagem));
        }
        
        // Método (métodos de classes abstratas tem que ser do tipo protegidos) genérico que executa qualquer validação de qualquer entidade
        // os wheres especifica que a classe não possa aceitrar qualquer parâmeto, ou seja: TV = validação e TE entidade
        // where TV : AbstractValidator<TE> (ou seja TV recebe uma classe AbstractValidator que é a <TE>)
        // e where TE : Entity (TE precisa ser uma entidade)
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity 
        {
            // Variavel recebe a validação do da entidade
            var validator = validacao.Validate(entidade);

            // Verifica se o validador é valido
            if (validator.IsValid) return true;

            // Caso o validador não seja válido adiciona a mensagem no método
            Notificar(validator);

            // retorna o resultado da validação
            return false;
        }
    }
}
