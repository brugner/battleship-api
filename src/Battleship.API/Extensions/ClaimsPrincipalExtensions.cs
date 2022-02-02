using System;
using System.Security.Claims;
using Battleship.API.Core.Exceptions;

namespace Battleship.API.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static int GetId(this ClaimsPrincipal claimsPrincipal)
    {
        var id = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == "id");

        if (id == null)
        {
            throw new AppUnauthorizedException("Unauthorized");
        }

        return Convert.ToInt32(id.Value);
    }
}