// 
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class MeuMiddleware{
    
    // Responsável por trabalhar com a chamada do próximo Missleware dentro do Pipeline
    private readonly RequestDelegate _next;

    // Construtor que recebe uma injeção de dependência através do RequestDelegate
    public MeuMiddleware(RequestDelegate next)
    {
        // Repassa a instância para a propriedade declarada
        _next = next;
    }

    // Este métdo é chamado, toda a vez que o Middleware for chamado.
    // Este método recebe a instância do contexto http que está rodando no momento da requisição
    public async Task InvokeAsync(HttpContext context){
        
        // Escreve na tela, quando estiver no Middleware
        Console.WriteLine("\n\r ------ Antes ------- \n\r");

        // Chama o próximo Middleware passando a referência do contexto
        await _next(context);

        // Escreve na tela, quando retornar para o Middleware
        Console.WriteLine("\n\r ------ Depois ------- \n\r");

        // Dentro desse método podemos adicionar o nosso código, por exe:
        // Capturar a url e fazer um apontamento
    }

}


// Essa nova classe, está sendo criada aqui para não ter que criar um arquivo fisico e ela será uma extensão da classe MeuMiddleware
public static class MeuMiddlewareExtension
{

    // Extension Method, ou seja um método de extenção
    // Onde adicionamos o IApplicationBuilder que será a interface que irá fazer a chamada
    //      através do método UseMeuMiddleware onde o this dentro desse método,
    //      significa que estamos criando um método de extensão dentro dessa interface,
    //      ou seja: estamos dizendo para criarmos o UseMeuMiddleware dentro da IApplicationBuilder
    //      e o  builder significa, a instância do IApplicationBuilder dentro desse método que vai ser utilizado.
    // Criamos uma instância do método builder para que não tenhamos que adicionalo diretamente na Startup.cs
    public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder){

        // Adiciona a instância do método builder
        return builder.UseMiddleware<MeuMiddleware>();
    }

}
