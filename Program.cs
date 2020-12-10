using ChallengeDBCCompany.Services;
using ChallengeDBCCompany.Services.Contracts;
using System;

namespace ChallengeDBCCompany
{
    /// <summary>
    ///     Modifique <see cref="_pathIn"/> e <see cref="_pathOut"/> de acordo
    ///     com o caminho correspondente.
    ///     
    ///     De start na aplicação e coloque os arquivos no diretório <see cref="_pathIn"/>.
    ///     Verifique as saídas em <see cref="_pathOut"/>.
    /// </summary>
    class Program
    {       
        private static string _pathIn = @"T:\Data\In";
        private static string _pathOut = @"T:\Data\Out";
        private static string _fileType = "*.dat";
        private static IWatchDirectoryService _watchDirectorySupport;

        static void Main(string[] args)
        {
            _watchDirectorySupport = new WatchDirectoryService(_pathIn, _pathOut, _fileType);

            _watchDirectorySupport.WatchNewFiles();
            Console.ReadLine();
        }
    }
}
