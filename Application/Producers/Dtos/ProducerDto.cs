using Application.Common.Mappings;
using Domain.Aggregates;

namespace Application.Producers.Dtos
{
    public class ProducerDto : IMapFrom<Producer>, IMapTo<Producer>
    {
        public bool isPies { get; set; } = false;

        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FarmName { get; set; } = string.Empty;
        public AddressDto FarmAddress { get; set; } = new();
    }
}