using Application.Services.Interfaces;
using Domain.Aggregates;
using MediatR;

namespace Application.Articles.Commands
{
    public record DeleteArticleCommand(int Id) : IRequest
    { }

    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly IGenericRepository<Article> _repository;

        public DeleteArticleCommandHandler(IGenericRepository<Article> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            Article persistentEntity = await _repository.Get(request.Id);
            await _repository.Delete(persistentEntity);
        }
    }
}
