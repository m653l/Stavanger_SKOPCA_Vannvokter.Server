﻿using Application.Services.Interfaces;
using Domain.Aggregates;
using Infrastructure.Database.Data;
using Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
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

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var dbContext = serviceProvider.GetService<DataContext>();
                dbContext.Database.Migrate();
            }

            services.AddTransient<IGenericRepository<Producer>, GenericRepository<Producer>>();
            services.AddTransient<IGenericRepository<Submition>, GenericRepository<Submition>>();
            services.AddTransient<IProducersRepository, ProducersRepository>();
            services.AddTransient<ISubmitionsRepository, SubmitionsRepository>();

            return services;
        }
    }
}
