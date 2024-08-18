
namespace LoggerModule
{
    public abstract class Logger() : ILogger
    {
        public abstract string Date { get; }

        public abstract void Chat(string message);

        public abstract void Log(string message);

        public abstract void Log(string[] messages);
    }
}
