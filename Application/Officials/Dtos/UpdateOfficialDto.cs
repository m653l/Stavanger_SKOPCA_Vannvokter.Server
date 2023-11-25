using AutoMapper;
using Domain.Aggregates;

namespace Application.Officials.Dtos
{
    public class UpdateOfficialDto : OfficialDto
    {
        public int Id { get; set; }

        public new static void Mapping(Profile profile)
        {
            profile.CreateMap<Official, UpdateOfficialDto>()
                .IncludeBase<Official, OfficialDto>()
                .ReverseMap();
        }
    }
}
