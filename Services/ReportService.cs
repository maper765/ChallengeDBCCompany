﻿using ChallengeDBCCompany.BuildingBlocks;
using ChallengeDBCCompany.Dtos;
using ChallengeDBCCompany.Services.Contracts;
using System.Linq;
using System.Text;

namespace ChallengeDBCCompany.Services
{
    public class ReportService : IReportService
    {
        private readonly FileSupport _fileSupport;

        public ReportService(string pathOut)
        {
            _fileSupport = new FileSupport(pathOut);
        }

        public void WriteReportInDisk(ReportDataDto report, string filePath)
        {
            StringBuilder writeReport = new StringBuilder();

            writeReport.AppendLine($"Number of customers in the input file: {report.Customers.Count}.");
            writeReport.AppendLine($"Number of salesman in the input file: {report.Salesmans.Count}.");
            writeReport.AppendLine($"ID Most expensive sale: {report.Sales.GroupBy(g => new { g.SaleId, Price = g.Items.Max(s => s.Price) }).OrderByDescending(o => o.Key.Price).FirstOrDefault().Key.SaleId}");
            writeReport.AppendLine($"The worst salesman: {report.Sales.GroupBy(g => new { g.SalesmanName, Price = g.Items.Min(s => s.Price) }).OrderBy(o => o.Key.Price).FirstOrDefault().Key.SalesmanName}.");

            _fileSupport.CreateFile(filePath, writeReport);
        }
    }
}
