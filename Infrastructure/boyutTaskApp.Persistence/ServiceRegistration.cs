using Microsoft.EntityFrameworkCore;
using boyutTaskAppAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using boyutTaskAppAPI.Applicaton.Repositories;
using boyutTaskAppAPI.Applicaton.Settings;
using boyutTaskAppAPI.Persistence.Repositories.User;

namespace boyutTaskAppAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddDbContextPool<boyutTaskAppDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

        }
    }
}
