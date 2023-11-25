using Application.Services.Interfaces;
using Domain.Aggregates;
using Infrastructure.Database.Data;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(@"Data Source=.\\VannvokterDB.db;");
            });

            services.AddTransient<IGenericRepository<Test>, GenericRepository<Test>>();

            return services;
        }
    }
}
