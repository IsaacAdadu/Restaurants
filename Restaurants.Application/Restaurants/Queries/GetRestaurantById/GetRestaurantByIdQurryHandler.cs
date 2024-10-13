

using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQurryHandler(ILogger<GetRestaurantByIdQurryHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetRestaurantByIdQuerry, RestaurantDto>
    {
        public async Task<RestaurantDto> Handle(GetRestaurantByIdQuerry request, CancellationToken cancellationToken)
        { 
            logger.LogInformation("Getting restaurant {RestaurantId}",request.Id);
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(Restaurant), request.Id.ToString());

            var restaurantDto = mapper.Map<RestaurantDto >(restaurant);
            return restaurantDto;
        }
    }
}
