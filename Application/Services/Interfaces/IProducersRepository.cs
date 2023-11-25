using Domain.Aggregates;

namespace Application.Services.Interfaces
{
    public interface IProducersRepository
    {
        Task<int> AddSubmissions(int producerId, Submission submission);
    }
}
