using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static void AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("RestaurantsDb");
            services.AddDbContext<RestaurantsDbContext>(options =>options.UseSqlServer(connectionstring));

            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        }
    }
}
