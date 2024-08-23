
using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants
{
    public class GetAllRestaurantsQuerry: IRequest<IEnumerable<RestaurantDto>>
    {
    }
}
