namespace DevIO.Business.Core.Notifications
{
    // Recebe a mensagem pelo construtor e seta a mesma para a propriedade
    public class Notificacao
    {
        // construtor
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        // Propriedade
        public string Mensagem { get; }
    }
}
