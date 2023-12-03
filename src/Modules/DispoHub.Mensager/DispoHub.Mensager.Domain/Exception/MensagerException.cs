using DispoHub.Mensager.Domain.Enums;

namespace DispoHub.Mensager.Domain.Exception
{
    public class MensagerException : System.Exception
    {
        public MensagerException()
        { }

        public MensagerException(string message)
            : base(message) { }

        public MensagerException(eEventType type, string message)
            : base($"Não foi possível concluir a operação, Tipo do erro: {nameof(type)}. Erro: {message}") { }

        public MensagerException(string message, System.Exception innerException)
            : base(message, innerException) { }
    }
}
