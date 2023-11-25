using Domain.Common;
using Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace Domain.Aggregates
{
    public class Producer : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FarmName { get; set; } = string.Empty;
        public Address FarmAddress { get; set; } = new();

        [JsonIgnore]
        public ICollection<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
