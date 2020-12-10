using System.Collections.Generic;

namespace ChallengeDBCCompany.Dtos
{
    public class SaleDto
    {
        public SaleDto()
        {
            Items = new List<ItemDto>();
        }

        public string FormatId { get; set; }
        public int SaleId { get; set; }
        public IEnumerable<ItemDto> Items { get; set; }
        public string SalesmanName { get; set; }
    }
}
