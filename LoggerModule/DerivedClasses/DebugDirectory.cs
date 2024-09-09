using AppDirectoryModule;

namespace LoggerModule.DerivedClasses
{
    public class DebugDirectory(string rootDir, string folderName) : AppDirectory(rootDir)
    {
        private readonly string _folderName = folderName;

        public override string GetAppDirectory()
        {
            return $"{RootDirectory}\\{_folderName}";
        }
    }
}
