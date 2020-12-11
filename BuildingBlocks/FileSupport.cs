using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDBCCompany.BuildingBlocks
{
    public sealed class FileSupport
    {
        private readonly string _pathOut;

        public FileSupport(string pathOut)
        {
            _pathOut = pathOut;
        }

        public void CreateFile(string filePath, StringBuilder report)
        {
            var filename = $"{Path.GetFileNameWithoutExtension(filePath)}.done.{Path.GetExtension(filePath)}";
            var filePathOut = Path.Combine(_pathOut, filename);

            using FileStream stream = new FileStream(filePathOut, FileMode.Create, FileAccess.ReadWrite);
            using StreamWriter streamWriter = new StreamWriter(stream);
            streamWriter.WriteLine(report);
            report.Clear();
        }

        public async Task CreateFileAsync(string filePath, StringBuilder report)
        {
            var filename = $"{Path.GetFileNameWithoutExtension(filePath)}.done.{Path.GetExtension(filePath)}";
            var filePathOut = Path.Combine(_pathOut, filename);

            using FileStream stream = new FileStream(filePathOut, FileMode.Create, FileAccess.ReadWrite);
            using StreamWriter streamWriter = new StreamWriter(stream);
            await streamWriter.WriteLineAsync(report);
            report.Clear();
        }
    }
}
