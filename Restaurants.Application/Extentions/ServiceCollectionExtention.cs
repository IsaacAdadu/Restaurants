
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Restaurants.Application.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ServiceCollectionExtentions).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

            services.AddAutoMapper(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly)
                .AddFluentValidationAutoValidation();
           
        }
    }
}
