using Application.Officials.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Officials.Queries
{
    public class GetOfficialQuery : IRequest<OfficialDto>
    {
        public int Id { get; set; }

        public GetOfficialQuery(int id)
        {
            Id = id;
        }
    }

    public class GetOfficialQueryHandler : IRequestHandler<GetOfficialQuery, OfficialDto>
    {
        private readonly IGenericRepository<Official> _repository;
        private readonly IMapper _mapper;

        public GetOfficialQueryHandler(IGenericRepository<Official> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OfficialDto> Handle(GetOfficialQuery request, CancellationToken cancellationToken)
        {
            Official entity = await _repository.Get(request.Id);
            OfficialDto officialDto = _mapper.Map<OfficialDto>(entity);

            return officialDto;
        }
    }
}
