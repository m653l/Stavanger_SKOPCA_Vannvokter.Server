using Domain.Aggregates;
using Domain.Enums;

namespace Application.Services.Interfaces
{
    public interface ISubmissionsRepository
    {
        public Task<Submission> GetSubmissionById(int id);
        public Task<List<Submission>> GetAllSubmissions();
        public Task<List<Submission>> GetSubmissionsByType(SubmissionType submissionType);
        public Task<List<Submission>> GetSubmissionsByDate(DateTime fromDate, DateTime untilDate);
    }
}
