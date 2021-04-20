using FluentValidation;

namespace DevIO.Business.Models.Fornecedores.Validations
{
    // Implementa a herança da classe AbstracValidator para o endereço do Fornecedor
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        // Efetua as validações dentro do construtor
        public EnderecoValidation()
        {
            // regras do campo Nome
            RuleFor(expression: c => c.Logradouro) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(1, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima

            // regras do campo Bairro
            RuleFor(expression: c => c.Bairro) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(5, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima

            // regras do campo CEP
            RuleFor(expression: c => c.Cep) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(8).WithMessage("O campo {PropertyName} precisa ter entre {MaxLength} caracteres"); // Quantidade máxima

            // regras do campo Cidade
            RuleFor(expression: c => c.Cidade) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(5, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima

            // regras do campo Estado
            RuleFor(expression: c => c.Estado) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(5, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima

            // regras do campo Numero
            RuleFor(expression: c => c.Numero) // Recebe o campo
                    .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                    .Length(1, 5).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima
        }
    }
}
