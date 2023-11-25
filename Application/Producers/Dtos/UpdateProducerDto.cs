using AutoMapper;
using Domain.Aggregates;

namespace Application.Producers.Dtos
{
    public class UpdateProducerDto : ProducerDto
    {
        public int Id { get; set; }

        public new static void Mapping(Profile profile)
        {
            profile.CreateMap<Producer, UpdateProducerDto>()
                .IncludeBase<Producer, ProducerDto>()
                .ReverseMap();
        }
    }
}
