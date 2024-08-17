using AppDirectoryModule;

namespace LoggerModule
{
    public class DebugDirectory : AppDirectory
    {
        public string DebugDir => $"{RootDirectory}\\ProjectLogs";

        public DebugDirectory(string rootDir) : base(rootDir)
        {
            CreateAppDirectory(DebugDir);
        }

        public string GetLastLog()
        {
            var logs = GetDirectoryFiles(DebugDir);

            if (logs.Any())
            {
                return logs.Last();
            }
            return "dummylog_0.txt";
        }

        public static int GetLogIdentity(string logFile)
        {
            return int.Parse(logFile.Split('_').Last().Split('.').First());
        }
    }
}
