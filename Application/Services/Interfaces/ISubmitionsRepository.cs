using Domain.Aggregates;

namespace Application.Services.Interfaces
{
    public interface ISubmitionsRepository
    {
        Task<Submition> GetSubmitionById(int id);
    }
}
