using LoggerModule.Interfaces;

namespace LoggerModule.BaseClasses
{
    public abstract class Logger() : ILogger
    {
        public string Date => $"{DateTime.Now:G}";

        public abstract void Chat(string message);

        public abstract void Log(string message);

        public abstract void Log(string[] messages);

        public abstract void Log(string message, Exception exception);

        public abstract void Log(string[] message, Exception exception);
    }
}
