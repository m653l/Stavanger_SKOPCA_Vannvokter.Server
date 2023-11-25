using Domain.Aggregates;

namespace Application.Services.Interfaces
{
    public interface IProducersRepository
    {
        Task<int> AddSubmitions(int producerId, Submition submition);
    }
}
