using Application.Services.Interfaces;
using Domain.Aggregates;
using Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    internal class SubmissionsRepository : GenericRepository<Submission>, ISubmissionsRepository
    {
        public SubmissionsRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Submission> GetSubmissionById(int id)
        {
            return await _dataContext.Submissions.Include(e => e.Producer).FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception();
        }

        public async Task<List<Submission>> GetAllSubmissions()
        {
            return await _dataContext.Submissions.Include(e => e.Producer).ToListAsync() ?? throw new Exception();
        }

        public async Task<List<Submission>> GetSubmissionsByDate(DateTime fromDate, DateTime untilDate)
        {
            return await _dataContext.Submissions.Where(c => c.SubmissionDate >= fromDate && c.SubmissionDate <= untilDate ).ToListAsync();
        }
    }
}
