using ChallengeDBCCompany.Dtos;

namespace ChallengeDBCCompany.Services.Contracts
{
    /// <summary>
    ///     Abstração da geração de relatórios.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        ///     Escreve dados do relório em um arquivo no disco.
        /// </summary>
        /// <param name="report">Instância de <see cref="ReportDataDto"/>.</param>
        /// <param name="filePath">Caminho e nome do arquivo de origem no disco.</param>
        void WriteReportInDisk(ReportDataDto report, string filePath);
    }
}
