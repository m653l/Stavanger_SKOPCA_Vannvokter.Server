using Application.Common.Mappings;
using Domain.Aggregates;

namespace Application.Articles.Dtos
{
    public class ArticleDto : IMapFrom<Article>, IMapTo<Article>
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
