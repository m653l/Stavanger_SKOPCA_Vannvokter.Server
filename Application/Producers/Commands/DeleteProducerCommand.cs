using Application.Services.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Producers.Commands
{
    public record DeleteProducerCommand(int Id) : IRequest
    { }

    public class DeleteProducerCommandHandler : IRequestHandler<DeleteProducerCommand> 
    {
        private readonly IGenericRepository<Producer> _repository;

        public DeleteProducerCommandHandler(IGenericRepository<Producer> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteProducerCommand request, CancellationToken cancellationToken)
        {
            Producer persistentEntity = await _repository.Get(request.Id);
            await _repository.Delete(persistentEntity);
        }
    }
}
