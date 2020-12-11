using ChallengeDBCCompany.BuildingBlocks;
using ChallengeDBCCompany.Dtos;

namespace ChallengeDBCCompany.Templates
{
    /// <summary>
    ///     Template para venda.
    /// </summary>
    public class Template003 : ITemplate
    {
        public void BindTemplateInReportData(ReportDataDto report, string[] parts) =>
            report.Sales.Add(new SaleDto
            {
                FormatId = parts[0],
                SaleId = int.Parse(parts[1]),
                Items = DataParseSupport.ToItemList(parts[2]),
                SalesmanName = parts[3]
            });
    }
}
