using Domain.Common;

namespace Domain.Aggregates
{
    public class Test : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
    }
}
