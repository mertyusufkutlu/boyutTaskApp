﻿using Microsoft.EntityFrameworkCore;
using boyutTaskAppAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using boyutTaskAppAPI.Applicaton.Repositories;
using boyutTaskAppAPI.Applicaton.Repositories.Customer;
using boyutTaskAppAPI.Applicaton.Repositories.CustomerBasket;
using boyutTaskAppAPI.Applicaton.Repositories.Order;
using boyutTaskAppAPI.Applicaton.Repositories.Product;
using boyutTaskAppAPI.Applicaton.Repositories.ProductGroup;
using boyutTaskAppAPI.Applicaton.Settings;
using boyutTaskAppAPI.Persistence.Repositories.Customer;
using boyutTaskAppAPI.Persistence.Repositories.CustomerBasket;
using boyutTaskAppAPI.Persistence.Repositories.Order;
using boyutTaskAppAPI.Persistence.Repositories.Product;
using boyutTaskAppAPI.Persistence.Repositories.ProductGroup;
using boyutTaskAppAPI.Persistence.Repositories.User;
using OneDose.ClaimIdentity.Model;

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
            services.AddScoped<ICustomerBasketReadRepository, CustomerBasketReadRepository>();
            services.AddScoped<ICustomerBasketWriteRepository, CustomerBasketWriteRepository>();
            services.AddScoped<IProductGroupWriteRepository, ProductGroupWriteRepository>();
            services.AddScoped<IProductGroupReadRepository, ProductGroupReadRepository>();
            services.AddSingleton<ISsoParameters, SsoParameters>();
        }
    }
}