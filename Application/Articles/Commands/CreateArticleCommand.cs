using Application.Articles.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Articles.Commands
{
    public record CreateArticleCommand(ArticleDto Article) : IRequest<int>
    { }

    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
    {
        private readonly IGenericRepository<Article> _repository;
        private readonly IMapper _mapper;

        public CreateArticleCommandHandler(IGenericRepository<Article> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            Article entity = _mapper.Map<Article>(request.Article);

            if (entity.Id == default)
                await _repository.Create(entity);
            else
                await _repository.Update(entity);

            return entity.Id;
        }
    }
}
