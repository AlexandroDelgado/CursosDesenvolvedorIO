using DevIO.Business.Core.Models;
using FluentValidation;

namespace DevIO.Business.Core.Services
{
    // É uma classe asbrastra, ou seja não pode ser instânciada, apenas herdada
    public abstract class BaseService
    {
        // Método (métodos de classes abstratas tem que ser do tipo protegidos) genérico que executa qualquer validação de qualquer entidade
        // os wheres especifica que a classe não possa aceitrar qualquer parâmeto, ou seja: TV = validação e TE entidade
        // where TV : AbstractValidator<TE> (ou seja TV recebe uma classe AbstractValidator que é a <TE>)
        // e where TE : Entity (TE precisa ser uma entidade)
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity 
        {
            // Variavel recebe a validação do da entidade
            var validator = validacao.Validate(entidade);

            // retorna o resultado da validação
            return validator.IsValid;
        }
    }
}
