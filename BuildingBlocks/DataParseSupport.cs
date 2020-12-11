using ChallengeDBCCompany.Dtos;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace ChallengeDBCCompany.BuildingBlocks
{
    public sealed class DataParseSupport
    {
        public static IEnumerable<ItemDto> ToItemList(string value)
        {
            var items = new List<ItemDto>();
            var rows = value.TrimStart('[').TrimEnd(']').Split(',');

            Parallel.ForEach(rows, row =>
            {
                var itemsSplit = row.Split('-');
                items.Add(new ItemDto
                {
                    Id = int.Parse(itemsSplit[0]),
                    Quantity = int.Parse(itemsSplit[1]),
                    Price = double.Parse(itemsSplit[2], CultureInfo.InvariantCulture)
                });
            });

            return items;
        }
    }
}
