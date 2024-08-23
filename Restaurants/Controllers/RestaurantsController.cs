using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController(IMediator mediator): ControllerBase
    {
        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var restaurants = await mediator.Send(new GetAllRestaurantsQuerry()); 
            return Ok(restaurants);

        }
        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id) 
        {
            var restaurant =  await mediator.Send(new GetRestaurantByIdQuerry(id));
            if (restaurant == null)
                return NotFound();
            return Ok(restaurant);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant( CreateRestaurantCommand command)
        {
            int id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

    }
}
