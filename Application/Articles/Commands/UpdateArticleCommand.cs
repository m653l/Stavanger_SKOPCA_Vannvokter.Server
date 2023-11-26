using Application.Articles.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Articles.Commands
{
    public record UpdateArticleCommand(UpdateArticleDto Article) : IRequest<int>
    { }

    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, int>
    {
        private readonly IGenericRepository<Article> _repository;
        private readonly IMapper _mapper;

        public UpdateArticleCommandHandler(IGenericRepository<Article> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            Article currentEntity = await _repository.Get(request.Article.Id);
            Article updatedEntity = _mapper.Map(request.Article, currentEntity);

            await _repository.Update(updatedEntity);

            return updatedEntity.Id;
        }
    }
}
