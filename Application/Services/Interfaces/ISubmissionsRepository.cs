using Domain.Aggregates;

namespace Application.Services.Interfaces
{
    public interface ISubmissionsRepository
    {
        public Task<Submission> GetSubmissionById(int id);
        public Task<List<Submission>> GetSubmissionsByDate(DateTime fromDate, DateTime untilDate);
    }
}
