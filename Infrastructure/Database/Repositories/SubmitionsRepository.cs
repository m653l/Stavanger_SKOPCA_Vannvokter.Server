using Application.Services.Interfaces;
using Domain.Aggregates;
using Infrastructure.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Repositories
{
    internal class SubmitionsRepository : GenericRepository<Submition>, ISubmitionsRepository
    {
        public SubmitionsRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Submition> GetSubmitionById(int id)
        {
            return await _dataContext.Submition.Include(e => e.Producer).FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception();
        }

        public async Task<List<Submition>> GetSubmitionsByDate()
        {
            //_dataContext.Submition.Where(c => c. );
            throw new NotImplementedException();
        }
    }
}
