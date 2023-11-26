using Domain.Common;

namespace Domain.Aggregates
{
    public class Article : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Content {  get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
