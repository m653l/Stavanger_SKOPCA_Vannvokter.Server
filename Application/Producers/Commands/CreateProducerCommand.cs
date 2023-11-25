using Application.Producers.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Producers.Commands
{
    public record CreateProducerCommand(ProducerDto Producer) : IRequest<int>
    {
    }

    public class CreateProducerCommandHandler : IRequestHandler<CreateProducerCommand, int>
    {
        private readonly IGenericRepository<Producer> _repository;
        private readonly IMapper _mapper;

        public CreateProducerCommandHandler(IGenericRepository<Producer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProducerCommand request, CancellationToken cancellationToken)
        {
            Producer entity = _mapper.Map<Producer>(request.Producer);

            if (entity.Id == default) 
                await _repository.Create(entity);
            else
                await _repository.Update(entity);

            return entity.Id;
        }
    }
}
