using FluentValidation;

namespace DevIO.Business.Models.Produtos.Validations
{
    // Implementa a herança da classe AbstracValidator para o produto
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        // Efetua as validações dentro do construtor
        public ProdutoValidation()
        {
            // regras do campo Nome
            RuleFor(expression: p => p.Nome) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(1, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima

            // regras do campo Descrição
            RuleFor(expression: p => p.Descricao) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(1, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima

            // regras do campo Nome
            RuleFor(expression: p => p.Valor) // Recebe o campo
                    .GreaterThan(valueToCompare: -1)
                    .WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");
        }
    }
}
