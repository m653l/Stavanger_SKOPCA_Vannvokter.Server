using Application.Common.Mappings;
using Domain.Aggregates;

namespace Application.Officials.Dtos
{
    public class OfficialDto : IMapFrom<Official>, IMapTo<Official>
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
