using System;
using Ardalis.ApiEndpoints;
using Battleship.API.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Endpoints.Error;

[Route("/error")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorEndpoint : EndpointBaseSync.WithoutRequest.WithActionResult
{
    public override ActionResult Handle()
    {
        int code = StatusCodes.Status500InternalServerError;
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        if (context.Error is AppArgumentException)
            code = StatusCodes.Status400BadRequest;

        if (context.Error is AppUnauthorizedException)
            code = StatusCodes.Status401Unauthorized;

        if (context.Error is AppForbiddenException)
            code = StatusCodes.Status403Forbidden;

        return Problem(statusCode: code, title: context.Error.Message, instance: context.Path);
    }
}
