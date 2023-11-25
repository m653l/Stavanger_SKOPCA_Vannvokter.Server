using Domain.Common;

namespace Domain.Aggregates
{
    public class Official : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
