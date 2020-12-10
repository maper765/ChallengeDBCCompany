namespace ChallengeDBCCompany.Services.Contracts
{
    /// <summary>
    ///     Abstração da leitura de arquivos.
    /// </summary>
    public interface IDataImportService
    {
        /// <summary>
        ///     Lê um arquivo carregando dados conforme necessário descartando-os da memória.
        /// </summary>
        /// <param name="filePath">Caminho e nome do arquivo no disco.</param>
        void ReadFile(string filePath);
    }
}
