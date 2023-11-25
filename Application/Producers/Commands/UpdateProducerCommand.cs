using Application.Producers.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Producers.Commands
{
    public record UpdateProducerCommand(UpdateProducerDto Producer) : IRequest<int>
    {
    }

    public class UpdateProducerCommandHandler : IRequestHandler<UpdateProducerCommand, int>
    {
        private readonly IGenericRepository<Producer> _repository;
        private readonly IMapper _mapper;

        public UpdateProducerCommandHandler(IGenericRepository<Producer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProducerCommand request, CancellationToken cancellationToken)
        {
            Producer currentEntity = await _repository.Get(request.Producer.Id);
            Producer updatedEntity = _mapper.Map(request.Producer, currentEntity);

            await _repository.Update(updatedEntity);

            return updatedEntity.Id;
        }
    }
}
