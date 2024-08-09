﻿
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantsService, RestaurantsService>();
           
        }
    }
}
