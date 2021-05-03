using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaDemoMVC_2.ViewComponents
{
    // Seta um nome para facilitar a chamada do mesmo em outros lugares
    [ViewComponent(Name = "Carrinho")]
    // Para ter um View Component, é necessário que o mesmo herde da Classe ViewComponent pertencente ao MVC
    public class CarrinhoViewComponent : ViewComponent
    {
        // Propriedade
        public int ItensCarrinho { get; set; }

        // Construtor
        public CarrinhoViewComponent()
        {
            // Seta a propriedade para simular uma suposta consulta no banco de dados
            ItensCarrinho = 3; // Essa propriedade poderia ser uma model cheia de informações.
        }

        // Chama o método especifico InvokeAsync()
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Essa view não é uma view do MVC com controllers, na verdade ela é uma view simples criada na mão.
            return View(ItensCarrinho);
        }
    }
}
