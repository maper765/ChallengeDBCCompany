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
            _reportService = new ReportService(pathOut);
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
                    _ExtractDataBasedonLayout(report, parts);
            }

            _reportService.WriteReportInDisk(report, filePath);
            Console.WriteLine($"{filePath} file processed.");
        }

        private void _ExtractDataBasedonLayout(ReportDataDto report, string[] parts)
        {
            if (parts[0] == "001")
            {
                report.Salesmans.Add(new SalesmanDto
                {
                    FormatId = parts[0],
                    Document = parts[1],
                    Name = parts[2],
                    Salary = double.Parse(parts[3], CultureInfo.InvariantCulture)
                });
            }
            else if (parts[0] == "002")
            {
                report.Customers.Add(new CustomerDto
                {
                    FormatId = parts[0],
                    Document = parts[1],
                    Name = parts[2],
                    BusinessArea = parts[3]
                });
            }
            else if (parts[0] == "003")
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
}
