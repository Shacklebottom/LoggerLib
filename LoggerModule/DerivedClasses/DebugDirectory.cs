using AppDirectoryModule;

namespace LoggerModule.DerivedClasses
{
    public class DebugDirectory : AppDirectory
    {
        private readonly string _folderName;
        public string Directory => GetDebugDir();

        public DebugDirectory(string rootDir, string folderName) : base(rootDir)
        {
            _folderName = folderName;

            CreateAppDirectory(Directory);
        }

        private string GetDebugDir()
        {
            return $"{RootDirectory}\\{_folderName}";
        }

        public string GetLastLog()
        {
            var logs = GetDirectoryFiles(Directory);

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
