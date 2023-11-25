using AutoMapper;
using Domain.Aggregates;

namespace Application.Submissions.Dtos
{
    public class UpdateSubmissionDto : SubmissionDto
    {
        public int Id { get; set; }

        public new static void Mapping(Profile profile)
        {
            profile.CreateMap<Submission, UpdateSubmissionDto>()
                .IncludeBase<Submission, SubmissionDto>()
                .ReverseMap();
        }
    }
}
