using ChallengeDBCCompany.Dtos;
using ChallengeDBCCompany.Services.Contracts;
using ChallengeDBCCompany.Templates;
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

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
                FactoryTemplate.GetInstance(parts[0])
                    .BindTemplateInReportData(report, parts);
            }

            _reportService.Write(report, filePath);
            Console.WriteLine($"{filePath} file processed.");
        }

        public async Task ReadFileAsync(string filePath)
        {
            string line;
            var report = new ReportDataDto();

            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var parts = line.Split('ç');
                FactoryTemplate.GetInstance(parts[0])
                    .BindTemplateInReportData(report, parts);
            }

            await _reportService.WriteAsync(report, filePath);
            Console.WriteLine($"{filePath} file processed.");
        }

        //Mais performático, porém, mais complexo
        public void ReadFileWithSpan(string filePath)
        {
            string line;
            var report = new ReportDataDto();
            ArrayList parts = new ArrayList();

            using (var fs = File.OpenRead(filePath))
            using (var reader = new StreamReader(fs))
            while ((line = reader.ReadLine()) != null)
            {
                var span = line.AsSpan();

                // FormatId 
                var firstSeparatorPos = span.IndexOf('ç');
                string formatId = span.Slice(0, firstSeparatorPos).ToString();
                parts.Add(formatId);

                _ComposeParts(parts, ref span, ref firstSeparatorPos);

                string[] partsArr = new string[parts.Count];
                parts.CopyTo(partsArr);
                parts.Clear();

                FactoryTemplate.GetInstance(formatId)
                    .BindTemplateInReportData(report, partsArr);
            }

            _reportService.Write(report, filePath);
            Console.WriteLine($"{filePath} file processed.");
        }

        private void _ComposeParts(ArrayList parts, ref ReadOnlySpan<char> span, ref int firstSeparatorPos)
        {
            // Salesman | Customer
            if (parts.Contains("001") || parts.Contains("002"))
            {
                // Document
                span = span.Slice(firstSeparatorPos + 1);
                firstSeparatorPos = span.IndexOf('ç');
                string document = span.Slice(0, firstSeparatorPos).ToString();
                parts.Add(document);

                // Name
                span = span.Slice(firstSeparatorPos + 1);
                firstSeparatorPos = span.IndexOf('ç');
                string name = span.Slice(0, firstSeparatorPos).ToString();
                parts.Add(name);

                // Salesman
                if (parts.Contains("001"))
                {
                    // Salary
                    span = span.Slice(firstSeparatorPos + 1);
                    string salary = span.ToString();
                    parts.Add(salary);
                }

                // Customer
                if (parts.Contains("002"))
                {
                    // BusinessArea
                    span = span.Slice(firstSeparatorPos + 1);
                    string businessArea = span.ToString();
                    parts.Add(businessArea);
                }
            }
            // Sale
            else if (parts.Contains("003"))
            {
                // SaleId
                span = span.Slice(firstSeparatorPos + 1);
                firstSeparatorPos = span.IndexOf('ç');
                string document = span.Slice(0, firstSeparatorPos).ToString();
                parts.Add(document);

                // Items
                span = span.Slice(firstSeparatorPos + 1);
                firstSeparatorPos = span.IndexOf('ç');
                string items = span.Slice(0, firstSeparatorPos).ToString();
                parts.Add(items);

                // SalesmanName
                span = span.Slice(firstSeparatorPos + 1);
                string salesmanName = span.ToString();
                parts.Add(salesmanName);
            }
        }
    }
}
