using System.Collections.Generic;

namespace DevIO.Business.Core.Notifications
{
    // Interface das notificações
    public interface INotificador
    {
        // Método de Teste, para saber se album processo tem notifição
        bool TemNotificacao();
        
        // Lista as notificações existentes para um processo
        List<Notificacao> ObterNotificacoes();

        // Manipula o que acontece quando uma notificação é lançada
        void Handle(Notificacao notificacao);
    }
}
