using AutoMapper;
using Domain.Aggregates;

namespace Application.Submitions.Dtos
{
    public class UpdateSubmitionDto : SubmitionDto
    {
        public int Id { get; set; }

        public new static void Mapping(Profile profile)
        {
            profile.CreateMap<Submission, UpdateSubmitionDto>()
                .IncludeBase<Submission, SubmitionDto>()
                .ReverseMap();
        }
    }
}
