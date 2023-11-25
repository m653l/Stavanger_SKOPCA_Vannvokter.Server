using Application.Services.Interfaces;
using Domain.Aggregates;
using Infrastructure.Database.Data;

namespace Infrastructure.Database.Repositories
{
    internal class ProducersRepository : GenericRepository<Producer>, IProducersRepository
    {
        public ProducersRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<int> AddSubmissions(int producerId, Submission submission)
        {
            Producer producer = await Get(producerId);

            producer.Submissions.Add(submission);
            await Update(producer);

            return submission.Id;
        }
    }
}
