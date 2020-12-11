using ChallengeDBCCompany.Dtos;

namespace ChallengeDBCCompany.Templates
{
    /// <summary>
    ///     Abstração da ligação de dados no relatório.
    /// </summary>
    public interface ITemplate
    {
        /// <summary>
        ///     Realiza a ligação dos dados recebido na leitura do arquivo
        ///     no objeto <see cref="ReportDataDto"/>.
        /// </summary>
        /// <param name="report">Instância de <see cref="ReportDataDto"/>.</param>
        /// <param name="parts">Array que representa os atributos recuperados da leitura do arquivo.</param>
        void BindTemplateInReportData(ReportDataDto report, string[] parts);
    }
}
