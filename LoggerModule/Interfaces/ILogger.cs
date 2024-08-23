namespace LoggerModule.Interfaces
{
    public interface ILogger
    {
        string Date { get; }

        void Chat(string message);

        void Log(string message);

        void Log(string[] messages);

        void Log(string message, Exception exception);

        void Log(string[] message, Exception exception);
    }
}
