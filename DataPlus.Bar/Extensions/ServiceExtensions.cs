using DataPlus.Bar.Contracts.Logger;
using DataPlus.Bar.Contracts.Repositories;
using DataPlus.Bar.Contracts.Services;
using DataPlus.Bar.Entities;
using DataPlus.Bar.Repository;
using DataPlus.Bar.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataPlus.Bar.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerService>();
        }

        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:ConnectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IWrapperRepository, WrapperRepository>();
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IWrapperRepository, WrapperRepository>();
        }
    }
}
