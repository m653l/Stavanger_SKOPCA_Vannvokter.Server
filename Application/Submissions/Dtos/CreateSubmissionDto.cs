using Application.Common.Mappings;
using Application.Producers.Dtos;
using Domain.Aggregates;
using Domain.Enums;

namespace Application.Submissions.Dtos
{
    public class CreateSubmissionDto : IMapFrom<Submission>, IMapTo<Submission>
    {
        public DateTime SubmissionDate { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public DateTime DateOfExecution { get; set; } = DateTime.UtcNow;

        public AddressDto Address { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;

        public SubmissionType SubmissionType { get; set; }
        public SubmissionStatus SubmissionStatus { get; set; }
    }
}
