using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Extensions
{
    // Herda o Taghelper
    public class EmailTagHelper : TagHelper
    {
        // O TagHelperContext não será utilizando neste cenário, porque ele poussui um contexto que pode ser explorado em outras situações.
        // No context, você tem o nome da Tag, atributos da Tag e etc.
        // Nesse momemento apenas o TagHelperOutput vai ser o suficiente, onde ele vai obter as informações da Tag e irá processalas, querando uma outra saida.

        // Cria uma propriedade publica que seta um valor
        // Essa propriedade pode ser referenciada, graças a formatação kebab-case
        // Seta um atributo automático para a propriendate.
        public string EmailDomain { get; set; } = "desenvolvedor.io";

        // Método assincrono para o processo assincrono do Tag Helper
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Informa o formato de saida, que no caso é html
            // A letra A está informando o formato do html 
            // <a href="mailto:usuario@dominio.categoria">Contato</a>
            output.TagName = "a";

            // Seta a variavel com a informação do contato html
            var content = await output.GetChildContentAsync();

            // Seta a variavel com a saida inclementando a mesma com o @ e o dominio.
            var target = content.GetContent() + "@" + EmailDomain;

            // Seta os atributos do output
            output.Attributes.SetAttribute("href", "mailto:" + target);

            // Seta o conteudo da target
            output.Content.SetContent(target);

            //System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
            //_accessor.HttpContext?.Request?.GetDisplayUrl();
            //Request.Headers["Referer"].ToString();
        }
    }
}
