using Microsoft.EntityFrameworkCore;
using boyutTaskAppAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using boyutTaskAppAPI.Applicaton.Repositories;
using boyutTaskAppAPI.Applicaton.Repositories.Basket;
using boyutTaskAppAPI.Applicaton.Repositories.BasketItems;
using boyutTaskAppAPI.Applicaton.Repositories.Customer;
using boyutTaskAppAPI.Applicaton.Repositories.Order;
using boyutTaskAppAPI.Applicaton.Repositories.Product;
using boyutTaskAppAPI.Applicaton.Repositories.ProductGroup;
using boyutTaskAppAPI.Applicaton.Settings;
using boyutTaskAppAPI.Persistence.Repositories.Basket;
using boyutTaskAppAPI.Persistence.Repositories.BasketItem;
using boyutTaskAppAPI.Persistence.Repositories.Customer;
using boyutTaskAppAPI.Persistence.Repositories.Order;
using boyutTaskAppAPI.Persistence.Repositories.Product;
using boyutTaskAppAPI.Persistence.Repositories.ProductGroup;
using boyutTaskAppAPI.Persistence.Repositories.User;

namespace boyutTaskAppAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContextPool<boyutTaskAppDbContext>(options =>
                options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IProductGroupWriteRepository, ProductGroupWriteRepository>();
            services.AddScoped<IProductGroupReadRepository, ProductGroupReadRepository>();
            services.AddSingleton<ISsoParameters, SsoParameters>();
            
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
        }
    }
}