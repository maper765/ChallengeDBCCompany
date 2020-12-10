using ChallengeDBCCompany.Dtos;
using ChallengeDBCCompany.Services.Contracts;
using ChallengeDBCCompany.Templates;
using System;
using System.IO;

namespace ChallengeDBCCompany.Services
{
    public class DataImportService : IDataImportService
    {
        private readonly IReportService _reportService;

        public DataImportService(string pathOut)
        {
            _reportService = new ReportInDiskService(pathOut);
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
                FactoryTemplate.Make(parts[0]).BindTemplateInReportData(report, parts);
            }

            _reportService.Write(report, filePath);
            Console.WriteLine($"{filePath} file processed.");
        }
    }
}
