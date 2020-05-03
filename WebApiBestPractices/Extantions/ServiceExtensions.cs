using System.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiBestPractices.Contracts;
using WebApiBestPractices.Entities;
using WebApiBestPractices.Repositories;

namespace WebApiBestPractices.Extantions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMySqlContext(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration["mysqlconnection:connectionString"];
            service.AddDbContext<AppDbContext>(c => c.UseMySql(connectionString));
        }

        public static void ConfigureRepositories(this IServiceCollection service)
        {
            //service.AddScoped<IOwnerRepository, OwnerRepository>();
            //service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

    }
}
