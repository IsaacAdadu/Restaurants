

using MediatR;
using Restaurants.Application.Restaurants.Dtos;
using System.Diagnostics.Contracts;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuerry(int id): IRequest<RestaurantDto>
    {
        public int Id { get; } = id;
       
    }
}
