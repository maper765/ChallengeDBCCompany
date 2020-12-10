using System.IO;
using System.Text;

namespace ChallengeDBCCompany.BuildingBlocks
{
    public sealed class FileSupport
    {
        private readonly string _pathOut;

        public FileSupport(string pathOut)
        {
            _pathOut = pathOut;
        }

        public void CreateFile(string filePath, StringBuilder sb)
        {
            var filename = $"{Path.GetFileNameWithoutExtension(filePath)}.done.{Path.GetExtension(filePath)}";
            var filePathOut = Path.Combine(_pathOut, filename);

            if (!File.Exists(filePathOut))
                File.Create(filePathOut).Close();

            TextWriter archive = File.AppendText(filePathOut);
            archive.WriteLine(sb);
            sb.Clear();
            archive.Close();
        }
    }
}
