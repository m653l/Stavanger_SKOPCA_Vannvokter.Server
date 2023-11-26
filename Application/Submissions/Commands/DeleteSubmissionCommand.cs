using Application.Services.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Submissions.Commands
{
    public record DeleteSubmissionCommand(int Id) : IRequest
    { }

    public class DeleteSubmissionCommandHandler : IRequestHandler<DeleteSubmissionCommand> 
    {
        private readonly IGenericRepository<Submission> _repository;

        public DeleteSubmissionCommandHandler(IGenericRepository<Submission> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteSubmissionCommand request, CancellationToken cancellationToken)
        {
            Submission persistentEntity = await _repository.Get(request.Id);
            await _repository.Delete(persistentEntity);
        }
    }
}
