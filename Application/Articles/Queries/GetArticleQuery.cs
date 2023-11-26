using Application.Articles.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Articles.Queries
{
    public class GetArticleQuery : IRequest<ArticleDto>
    {
        public int Id { get; set; }

        public GetArticleQuery(int id)
        {
            Id = id;
        }
    }

    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleDto>
    {
        private readonly IGenericRepository<Article> _repository;
        private readonly IMapper _mapper;

        public GetArticleQueryHandler(IGenericRepository<Article> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ArticleDto> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            Article entity = await _repository.Get(request.Id);
            ArticleDto articleDto = _mapper.Map<ArticleDto>(entity);

            return articleDto;
        }
    }
}
