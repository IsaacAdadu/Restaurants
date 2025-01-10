﻿

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Restaurants.Domain.Entities;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Restaurants.Infrastructure.Authorization
{
    public class RestaurantsUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public RestaurantsUserClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
        {
            public override async Task<ClaimsPrincipal> CreateAsync(User user)
            {
                var id = await GenerateClaimsAsync(user);
                if(user.Nationality != null)
                {
                id.AddClaim(new Claim("Nationality", user.Nationality));
                }

               if (user.DateOfBirth != null)
               {
                  id.AddClaim(new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-mm-dd")));
               }

               return new ClaimsPrincipal(id);

            }
         }
    }
}
