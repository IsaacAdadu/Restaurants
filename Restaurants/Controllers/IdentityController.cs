using Microsoft.AspNetCore.Mvc;

namespace Restaurants.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController
    {
        [HttpPatch("user")]
        public async <IActionResult> UpdateUserDetails()
        {

        }

    }
}
