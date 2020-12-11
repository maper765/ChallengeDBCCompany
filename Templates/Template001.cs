using ChallengeDBCCompany.Dtos;
using System.Globalization;

namespace ChallengeDBCCompany.Templates
{
    /// <summary>
    ///     Template para vendedor.
    /// </summary>
    public class Template001 : ITemplate
    {
        public void BindTemplateInReportData(ReportDataDto report, string[] parts) =>
            report.Salesmans.Add(new SalesmanDto
            {
                FormatId = parts[0],
                Document = parts[1],
                Name = parts[2],
                Salary = double.Parse(parts[3], CultureInfo.InvariantCulture)
            });
    }
}
