using ChallengeDBCCompany.Services.Contracts;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ChallengeDBCCompany.Services
{
    public sealed class WatchDirectoryService : IWatchDirectoryService
    {
        private readonly FileSystemWatcher _watchFile;
        private readonly IDataImportService _dataImportService;
        private readonly string _pathIn;
        private readonly string _fileType;

        public WatchDirectoryService(string pathIn, string pathOut, string fileType)
        {
            _pathIn = pathIn;
            _fileType = fileType;
            _dataImportService = new DataImportService(pathOut);

            _watchFile = new FileSystemWatcher(_pathIn, _fileType)
            {
                IncludeSubdirectories = true
            };
        }

        public void WatchNewFiles()
        {
            _watchFile.Created += new FileSystemEventHandler(_OnFileChanged);
            _watchFile.EnableRaisingEvents = true;

            Console.WriteLine($"Monitoring {_fileType} file in {_pathIn}");
        }

        private void _OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Created)
                return;

            var file = Path.Combine(_pathIn, Path.GetFileName(e.Name));

            try
            {
                Task.Run(() =>
                    _dataImportService.ReadFileAsync(file)).Wait();
                //_dataImportService.ReadFile(file);
            }
            catch 
            {
                Console.WriteLine($"Error processing {file}.");
            }             
        }
    }
}
