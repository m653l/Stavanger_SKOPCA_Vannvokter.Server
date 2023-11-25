using Application.Producers.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Producers.Queries
{
    public class GetProducerQuery : IRequest<ProducerDto>
    {
        public int Id { get; set; }

        public GetProducerQuery(int id)
        {
            Id = id;
        }
    }

    public class GetProducerQueryHandler : IRequestHandler<GetProducerQuery, ProducerDto>
    {
        private readonly IGenericRepository<Producer> _repository;
        private readonly IMapper _mapper;

        public GetProducerQueryHandler(IGenericRepository<Producer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProducerDto> Handle(GetProducerQuery request, CancellationToken cancellationToken)
        {
            Producer? producer = await _repository.Get(request.Id);

            if (producer is null)
                throw new Exception();

            ProducerDto producerDto = _mapper.Map<ProducerDto>(producer);

            return producerDto;
        }
    }
}
