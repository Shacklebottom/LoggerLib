
namespace LoggerModule
{
    public abstract class Logger() : ILogger
    {
        public string Date => $"{DateTime.Now:MM-dd-yyyy hh-mm-ss tt}";

        public abstract void Chat(string message);

        public abstract void Log(string message);

        public abstract void Log(string[] messages);
    }
}
