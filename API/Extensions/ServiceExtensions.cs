using Core.Interfaces;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            // Configure DB Context
            services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                opt.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            });

            // Redis Connection
            services.AddSingleton<IConnectionMultiplexer>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var connString = config.GetConnectionString("Redis")
                    ?? throw new Exception("Cannot get redis connection string");
                var configuration = ConfigurationOptions.Parse(connString, true);
                return ConnectionMultiplexer.Connect(configuration);
            });

            // Scoped Services
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICouponService, CouponService>();

            // Singleton Services
            services.AddSingleton<ICartService, CartService>();
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            // CORS
            services.AddCors();

            // SignalR
            services.AddSignalR();

            // Add Swagger Services
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "API Documentation for My Project"
                });
            });


            return services;
        }
    }
}
