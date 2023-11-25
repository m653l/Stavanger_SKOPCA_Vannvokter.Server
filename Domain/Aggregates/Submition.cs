using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class Submition : BaseEntity
    {
        public DateTime SubmitionDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime DateOfExecution {  get; set; } = DateTime.UtcNow;

        public FieldAddress FieldAddress { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public string Comments {  get; set; } = string.Empty;

        public SubmitionType SubmitionType { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; } = null!;
    }
}
