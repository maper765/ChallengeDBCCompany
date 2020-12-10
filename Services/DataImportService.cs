using ChallengeDBCCompany.BuildingBlocks;
using ChallengeDBCCompany.Dtos;
using ChallengeDBCCompany.Services.Contracts;
using System;
using System.Globalization;
using System.IO;

namespace ChallengeDBCCompany.Services
{
    public class DataImportService : IDataImportService
    {
        private readonly IReportService _reportService;
        private readonly DataParseSupport _dataParseSupport;

        public DataImportService(string pathOut)
        {
            _reportService = new ReportInDiskService(pathOut);
            _dataParseSupport = new DataParseSupport();
        }

        public void ReadFile(string filePath)
        {
            string line;
            var report = new ReportDataDto();

            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split('ç');
                    _ExtractDataBasedOnTemplate(report, parts);
            }

            _reportService.Write(report, filePath);
            Console.WriteLine($"{filePath} file processed.");
        }

        private void _ExtractDataBasedOnTemplate(ReportDataDto report, string[] parts)
        {
            switch (parts[0])
            {
                case "001":
                    _GetSalesmanTemplate(report, parts);
                    break;
                case "002":
                    _GetCustomerTemplate(report, parts);
                    break;
                case "003":
                    _GetSaleTemplate(report, parts);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void _GetSalesmanTemplate(ReportDataDto report, string[] parts)
        {
            report.Salesmans.Add(new SalesmanDto
            {
                FormatId = parts[0],
                Document = parts[1],
                Name = parts[2],
                Salary = double.Parse(parts[3], CultureInfo.InvariantCulture)
            });
        }

        private void _GetCustomerTemplate(ReportDataDto report, string[] parts)
        {
            report.Customers.Add(new CustomerDto
            {
                FormatId = parts[0],
                Document = parts[1],
                Name = parts[2],
                BusinessArea = parts[3]
            });
        }

        private void _GetSaleTemplate(ReportDataDto report, string[] parts)
        {
            report.Sales.Add(new SaleDto
            {
                FormatId = parts[0],
                SaleId = int.Parse(parts[1]),
                Items = _dataParseSupport.ToItemList(parts[2]),
                SalesmanName = parts[3]
            });
        }
    }
}
