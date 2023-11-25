using Application.Common.Mappings;
using Application.Producers.Dtos;
using Domain.Aggregates;
using Domain.Enums;

namespace Application.Submitions.Dtos
{
    public class SubmitionDto : IMapFrom<Submition>, IMapTo<Submition>
    {
        public DateTime SubmitionDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime DateOfExecution { get; set; } = DateTime.UtcNow;

        public AddressDto FieldAddress { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public double Quantity { get; set; }

        public SubmitionType SubmitionType { get; set; }
        public Producer Producer { get; set; }
    }
}
