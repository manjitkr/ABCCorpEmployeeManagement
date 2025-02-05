using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorpEmployeeManagement.Persistence.DatabaseContext;
using ABCCorpEmployeeManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABCCorpEmployeeManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeManagementDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EmployeeManagementDatabaseConnectionString"));
            }
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEmployeeRecordRepository, EmployeeRecordRepository>();

            return services;
        }
    }
}
