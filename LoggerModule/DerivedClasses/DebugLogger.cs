using AppDirectoryModule;
using LoggerModule.BaseClasses;
using LoggerModule.Interfaces;

namespace LoggerModule.DerivedClasses
{
    public class DebugLogger(DebugDirectory debugDir) : Logger, ILogger
    {
        public DebugDirectory DebugDir { get; private set; } = debugDir;

        public override void Chat(string message)
        {
            Console.WriteLine($"{Date} ==> {message}");
        }

        public override void Log(string message)
        {
            File.WriteAllText(GetLogPath(), message);
        }

        public override void Log(string[] messages)
        {
            File.WriteAllLines(GetLogPath(), messages);
        }

        public override void Log(string message, Exception exception)
        {
            File.WriteAllText(GetLogPath(), $"{message}\n{exception.Message}\n\n{exception.StackTrace}");
        }

        public override void Log(string[] message, Exception exception)
        {
            var messages = new List<string>(message)
            {
                "\n",
                exception.Message,
                "\n",
                exception.StackTrace ?? ""
            };

            File.WriteAllLines(GetLogPath(), messages);
        }

        private string GetLogPath()
        {
            string logFile = $"{Date}.txt";

            string logPath = $"{DebugDir.AppDir}\\{logFile}";

            return logPath;
        }
    }
}
