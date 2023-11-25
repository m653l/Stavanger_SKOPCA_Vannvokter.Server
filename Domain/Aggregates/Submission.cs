using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates
{
    public class Submission : BaseEntity
    {
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime DateOfExecution {  get; set; } = DateTime.UtcNow;

        public Address Address { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public double Quantity {  get; set; }

        public SubmissionType SubmissionType { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; } = null!;
    }
}
