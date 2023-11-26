using Application.Services.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Officials.Commands
{
    public record DeleteOfficialCommand(int Id) : IRequest
    { }

    public class DeleteOfficialCommandHandler : IRequestHandler<DeleteOfficialCommand>
    {
        private readonly IGenericRepository<Official> _repository;

        public DeleteOfficialCommandHandler(IGenericRepository<Official> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOfficialCommand request, CancellationToken cancellationToken)
        {
            Official persistentEntity = await _repository.Get(request.Id);
            await _repository.Delete(persistentEntity);
        }
    }
}
