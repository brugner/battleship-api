using Ardalis.ApiEndpoints;
using Battleship.API.Core.Contracts.Services;
using Battleship.API.Core.Models.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Battleship.API.Endpoints.Auth;

[Route("api/auth")]
[AllowAnonymous]
public class SignInEndpoint : EndpointBaseAsync.WithRequest<SignInInputDTO>.WithActionResult<SignInResultDTO>
{
    private readonly IAuthService _authService;

    public SignInEndpoint(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Signs in a user",
        Description = "Signs in a user and returns a JWT token.",
        OperationId = "Auth.SignIn",
        Tags = new[] { "Auth" })]
    public override async Task<ActionResult<SignInResultDTO>> HandleAsync(SignInInputDTO request, CancellationToken cancellationToken = default)
    {
        var result = await _authService.SignInAsync(request);

        return Ok(result);
    }
}
