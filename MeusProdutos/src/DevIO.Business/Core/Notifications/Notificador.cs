using System.Collections.Generic;
using System.Linq;

namespace DevIO.Business.Core.Notifications
{
    // Esta classe implementa a interface de notificações
    public class Notificador : INotificador
    {
        // Cria uma lista privada que irá armazenar as notificações
        private List<Notificacao> _notificacoes;

        // Construtor que recebe a notificação e adiciona a mesma à lista
        public Notificador()
        {
            // Instância a lista de notificações
            _notificacoes = new List<Notificacao>();
        }

        // Adiciona a notificação a lista
        public void Handle(Notificacao notificacao)
        {
            // Adiciona a notificação à lista
            _notificacoes.Add(notificacao);
        }

        // Obtem a lista de notificações
        public List<Notificacao> ObterNotificacoes()
        {
            // retorna a lista de notificações
            return _notificacoes;
        }

        // Retorna se possui notificações
        public bool TemNotificacao()
        {
            // retorna true para caso exista notificações e falso para quando não exista
            return _notificacoes.Any();
        }
    }
}
