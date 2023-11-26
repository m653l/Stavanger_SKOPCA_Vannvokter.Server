using AutoMapper;
using Domain.Aggregates;

namespace Application.Articles.Dtos
{
    public class UpdateArticleDto : ArticleDto
    {
        public int Id { get; set; }

        public new static void Mapping(Profile profile)
        {
            profile.CreateMap<Article, UpdateArticleDto>()
                .IncludeBase<Article, ArticleDto>()
                .ReverseMap();
        }
    }
}
