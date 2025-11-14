using eCommerce.BusinessLogicLayer.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.ProductsService.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        // allow to call the methods on program.cs file
        public static IServiceCollection AddDBusinessLogicLayer(this IServiceCollection services)
        {
            // Register your data access layer services here
            // e.g., services.AddScoped<IYourRepository, YourRepository>();
            services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile));


            return services;
        }
    }
}
