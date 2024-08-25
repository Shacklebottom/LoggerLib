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
    }
}
