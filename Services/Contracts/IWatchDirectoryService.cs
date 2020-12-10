namespace ChallengeDBCCompany.Services.Contracts
{
    /// <summary>
    ///     Abstração do monitoramento de arquivos.
    /// </summary>
    public interface IWatchDirectoryService
    {
        /// <summary>
        ///     Monitora a criação de novos arquivos em um determinado diretório no disco
        ///     e inicia o processamento das informações.
        /// </summary>
        void WatchNewFiles();
    }
}
