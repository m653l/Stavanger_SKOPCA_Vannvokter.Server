using Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
        public DataContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}