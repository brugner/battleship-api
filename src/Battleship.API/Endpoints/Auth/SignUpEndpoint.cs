using Ardalis.ApiEndpoints;
using Battleship.API.Core.Contracts.Services;
using Battleship.API.Core.Models.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Battleship.API.Endpoints.Auth;

[Route("api/auth")]
[AllowAnonymous]
public class SignUpEndpoint : EndpointBaseAsync.WithRequest<SignUpInputDTO>.WithActionResult<SignUpResultDTO>
{
    private readonly IAuthService _authService;

    public SignUpEndpoint(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("sign-up")]
    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Signs up a new user",
        Description = "Signs up a new user.",
        OperationId = "Auth.SignUp",
        Tags = new[] { "Auth" })]
    public override async Task<ActionResult<SignUpResultDTO>> HandleAsync(SignUpInputDTO request, CancellationToken cancellationToken = default)
    {
        var result = await _authService.SignUpAsync(request);

        return Ok(result);
    }
}


