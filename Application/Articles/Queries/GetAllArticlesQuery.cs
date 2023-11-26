using Application.Articles.Dtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Aggregates;
using MediatR;

namespace Application.Articles.Queries
{
    public class GetAllArticlesQuery : IRequest<List<ArticleDto>>
    {
    }

    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<ArticleDto>>
    {
        private readonly IGenericRepository<Article> _repository;
        private readonly IMapper _mapper;

        public GetAllArticlesQueryHandler(IGenericRepository<Article> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            List<Article> entity = _repository.GetAll().ToList();
            List<ArticleDto> articleDto = _mapper.Map<List<ArticleDto>>(entity);

            return articleDto;
        }
    }
}
