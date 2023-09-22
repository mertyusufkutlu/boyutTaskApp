using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace boyutTaskAppAPI.Applicaton;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(typeof(ServiceRegistration));
        collection.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "127.0.0.1:6379"; // Redis path
        });
    }
}