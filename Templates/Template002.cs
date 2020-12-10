using ChallengeDBCCompany.Dtos;

namespace ChallengeDBCCompany.Templates
{
    public class Template002 : ITemplate
    {
        public void BindTemplateInReportData(ReportDataDto report, string[] parts) =>
            report.Customers.Add(new CustomerDto
            {
                FormatId = parts[0],
                Document = parts[1],
                Name = parts[2],
                BusinessArea = parts[3]
            });
    }
}
