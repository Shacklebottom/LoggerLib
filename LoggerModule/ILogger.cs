
namespace LoggerModule
{
    public interface ILogger
    {
        string Date { get; }

        void Chat(string message);

        void Log(string message);

        void Log(string[] messages);
    }
}
