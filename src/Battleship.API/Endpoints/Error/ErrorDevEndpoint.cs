using System;
using Ardalis.ApiEndpoints;
using Battleship.API.Core.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Battleship.API.Endpoints.Error;

[Route("/error-dev")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorDevEndpoint : EndpointBaseSync.WithoutRequest.WithActionResult
{
    private readonly IHostEnvironment _environment;

    public ErrorDevEndpoint([FromServices] IHostEnvironment environment)
    {
        _environment = environment;
    }

    public override ActionResult Handle()
    {
        if (!_environment.IsDevelopment())
        {
            return NotFound();
        }

        int code = StatusCodes.Status500InternalServerError;
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

        if (context.Error is AppArgumentException)
            code = StatusCodes.Status400BadRequest;

        if (context.Error is AppUnauthorizedException)
            code = StatusCodes.Status401Unauthorized;

        if (context.Error is AppForbiddenException)
            code = StatusCodes.Status403Forbidden;

        return Problem(statusCode: code, title: context.Error.Message, instance: context.Path, detail: context.Error.StackTrace);
    }
}
