using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class Submission : BaseEntity
    {
        public DateTime SubmitionDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime DateOfExecution {  get; set; } = DateTime.UtcNow;

        public Address FieldAddress { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public double Quantity {  get; set; }

        public SubmitionType SubmitionType { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; } = null!;
    }
}
