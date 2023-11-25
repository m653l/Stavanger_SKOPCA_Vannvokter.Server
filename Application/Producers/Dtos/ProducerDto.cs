using Application.Common.Mappings;
using Domain.Aggregates;
using Domain.ValueObjects;

namespace Application.Producers.Dtos
{
    public class ProducerDto : IMapFrom<Producer>, IMapTo<Producer>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FarmName { get; set; } = string.Empty;
        public Address FarmAddress { get; set; } = new();
    }
}
