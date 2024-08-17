using AppDirectoryModule;

namespace LoggerModule
{
    public class DebugLogger(LoggerDirectory loggerDir) : Logger(), ILogger
    {
        public LoggerDirectory LoggerDirectory { get; private set; } = loggerDir;

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

        private string GetLogPath()
        {
            var lastLog = LoggerDirectory.GetLastLog();
            var logIdentity = LoggerDirectory.GetLogIdentity(lastLog);

            string logFile = $"{Date}_{logIdentity + 1}.txt";

            string logPath = $"{LoggerDirectory.LoggerDir}\\{logFile}";

            return logPath;
        }
    }
}
