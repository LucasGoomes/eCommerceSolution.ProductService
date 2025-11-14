using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.ProductsService.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
        {
            // Register your data access layer services here
            // e.g., services.AddScoped<IYourRepository, YourRepository>();



            return services;
        }
    }
}
