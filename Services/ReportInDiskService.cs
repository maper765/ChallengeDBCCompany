using ChallengeDBCCompany.BuildingBlocks;
using ChallengeDBCCompany.Dtos;
using ChallengeDBCCompany.Services.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeDBCCompany.Services
{
    /// <summary>
    ///     Escreve dados do relatório no disco local.
    /// </summary>
    public class ReportInDiskService : IReportService
    {
        private readonly FileSupport _fileSupport;

        public ReportInDiskService(string pathOut)
        {
            _fileSupport = new FileSupport(pathOut);
        }

        public void Write(ReportDataDto report, string filePath) =>
            _fileSupport.CreateFile(filePath, _WriteInReport(report));

        public async Task WriteAsync(ReportDataDto report, string filePath) =>
            await _fileSupport.CreateFileAsync(filePath, _WriteInReport(report));

        private static StringBuilder _WriteInReport(ReportDataDto report)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Number of customers in the input file: {report.Customers.Count}.");
            sb.AppendLine($"Number of salesman in the input file: {report.Salesmans.Count}.");
            sb.AppendLine($"ID Most expensive sale: {report.Sales.GroupBy(g => new { g.SaleId, Price = g.Items.Max(s => s.Price) }).OrderByDescending(o => o.Key.Price).FirstOrDefault().Key.SaleId}.");
            sb.AppendLine($"The worst salesman: {report.Sales.GroupBy(g => new { g.SalesmanName, Price = g.Items.Min(s => s.Price) }).OrderBy(o => o.Key.Price).FirstOrDefault().Key.SalesmanName}.");
            
            return sb;
        }
    }
}
