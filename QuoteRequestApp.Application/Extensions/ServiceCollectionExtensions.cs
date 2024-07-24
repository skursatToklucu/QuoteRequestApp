using Microsoft.Extensions.DependencyInjection;
using QuoteRequestApp.Application.Services.Interfaces;
using QuoteRequestApp.Application.Services;
using QuoteRequestApp.DataAccess.Repositories.Interfaces;
using QuoteRequestApp.DataAccess.Repositories;

namespace QuoteRequestApp.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IDimensionService, DimensionService>();
            services.AddScoped<IEnumService, EnumService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
