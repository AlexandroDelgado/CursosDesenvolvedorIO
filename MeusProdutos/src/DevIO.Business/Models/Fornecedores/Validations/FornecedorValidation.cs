using DevIO.Business.Core.Validations.Documentos;
using FluentValidation;

namespace DevIO.Business.Models.Fornecedores.Validations
{
    // Implementa a herança da classe AbstracValidator para o Fornecedor
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        // Efetua as validações dentro do construtor
        public FornecedorValidation()
        {
            // regras do campo Nome
            RuleFor(expression: f => f.Nome) // Recebe o campo
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido!") // Campo obrigatório
                .Length(5, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); // Quantidade minima e máxima

            // Regra de validação para CPF
            When(predicate: f => f.TipoFornecedor == TipoFornecedor.PessoaFisica, action: () => // Quando o tipo fornecedor for igual a pessoa física vá para a ação
            {
                // Valida a quantidade de caracteres do CPF
                RuleFor(expression: f => f.Documento.Length) // Verifica a quantidade de caracteres do documento
                    .Equal(toCompare: CpfValidacao.TamanhoCpf) // Compara com a quantidade de caracteres necessários para o CPF
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue caracteres e foi fornecido {PropertyValue}"); // Retorna a mensagem de erro

                // Valida a numeração do CPF
                RuleFor(expression: f => CpfValidacao.Validar(f.Documento)) // Passa o CPF para a validação
                    .Equal(toCompare: true) // Verifica o retorno do CPF
                    .WithMessage("O {PropertyName} fornecido é inválido!"); // Retorna a mensagem de erro
            });

            // Regra de validação para CNPJ
            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, action: () => // Quando o tipo fornecedor for igual a pessoa jurídica vá para a ação
            {
                // 
                RuleFor(expression: f => f.Documento.Length) // Verifica a quantidade de caracteres do documento
                    .Equal(toCompare: CnpjValidacao.TamanhoCnpj) // Compara com a quantidade de caracteres necessários para o CNPJ
                    .WithMessage("O campo {PropertyName} precisa ter {ComparisonValue caracteres e foi fornecido {PropertyValue}"); // Retorna a mensagem de erro

                // Valida a numeração do CNPJ
                RuleFor(expression: f => CnpjValidacao.Validar(f.Documento)) // Passa o CNPJ para a validação
                    .Equal(toCompare: true) // Verifica o retorno do CNPJ
                    .WithMessage("O {PropertyName} fornecido é inválido!"); // Retorna a mensagem de erro
            });
        }

    }
}
