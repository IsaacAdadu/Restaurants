

using MediatR;
using Restaurants.Application.Restaurants.Dtos;
using System.Diagnostics.Contracts;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById
{
    public class GetRestaurantByIdQuerry(int id, string userId): IRequest<RestaurantDto>
    {
        public int Id { get; } = id;
        public string UserId { get; set; } = userId;
       
    }
}
