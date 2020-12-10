using ChallengeDBCCompany.Dtos;

namespace ChallengeDBCCompany.Templates
{
    public interface ITemplate
    {
        void BindTemplateInReportData(ReportDataDto report, string[] parts);
    }
}
