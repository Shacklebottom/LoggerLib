using AppDirectoryModule;

namespace LoggerModule
{
    public class DebugLogger(DebugDirectory debugDir) : Logger(), ILogger
    {
        public override string Date => $"{DateTime.Now:MM-dd-yyyy hh-mm-ss tt}";

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

        private string GetLogPath()
        {
            var lastLog = DebugDir.GetLastLog();
            var logIdentity = DebugDirectory.GetLogIdentity(lastLog);

            string logFile = $"{Date}_{logIdentity + 1}.txt";

            string logPath = $"{DebugDir.DebugDir}\\{logFile}";

            return logPath;
        }
    }
}
