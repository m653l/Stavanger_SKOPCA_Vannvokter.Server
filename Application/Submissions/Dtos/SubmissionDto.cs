using Application.Common.Mappings;
using Application.Producers.Dtos;
using Domain.Aggregates;
using Domain.Enums;

namespace Application.Submissions.Dtos
{
    public class SubmissionDto : IMapFrom<Submission>, IMapTo<Submission>
    {
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime DateOfExecution { get; set; } = DateTime.UtcNow;

        public AddressDto FieldAddress { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public double Quantity { get; set; }

        public SubmissionType SubmissionType { get; set; }
        public Producer Producer { get; set; }
    }
}
