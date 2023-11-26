using Application.Common.Mappings;
using Domain.ValueObjects;

namespace Application.Producers.Dtos
{
    public class AddressDto : IMapFrom<Address>, IMapTo<Address>
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;

        public string GetAddressInOneString()
        {
            return string.Join(" ", Street, City, PostCode);
        }
    }
}
