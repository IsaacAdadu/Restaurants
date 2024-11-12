﻿
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Users.Commands
{
    public class UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger, IUserContext userContext, IUserStore<User> userStore) : IRequestHandler<UpdateUserDetailsCommand>
    {
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = userContext.GetCurrentUser();
            logger.LogInformation("Updating user: {UserId}, with {@Request}", user!.Id, request);

            var dbUser = await userStore.FindByIdAsync(user!.Id, cancellationToken);

        }
    }
}
