using System.Collections.Generic;

namespace ChallengeDBCCompany.Dtos
{
    public class ReportDataDto
    {
        public ReportDataDto()
        {
            Salesmans = new List<SalesmanDto>();
            Customers = new List<CustomerDto>();
            Sales = new List<SaleDto>();
        }

        public IList<SalesmanDto> Salesmans { get; set; }
        public IList<CustomerDto> Customers { get; set; }
        public IList<SaleDto> Sales { get; set; }
    }
}
