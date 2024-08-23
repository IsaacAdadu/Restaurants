

using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuerryHandler(ILogger<GetAllRestaurantsQuerryHandler> logger, IRestaurantsRepository restaurantsRepository) : IRequestHandler<GetAllRestaurantsQuerry, IEnumerable<RestaurantDto>>
    {
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuerry request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all restaurants");
            var restaurants = await restaurantsRepository.GetAllAsync();

            var restaurantsDto = restaurants.Select(RestaurantDto.FromEntity);
            return restaurantsDto!;
        }
    }
}
