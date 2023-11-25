using Domain.Common;

namespace Domain.Aggregates
{
    public class Submition : BaseEntity, IAggregateRoot
    {
        public string ProducerName { get; set; }

    }
}
