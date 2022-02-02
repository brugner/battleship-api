using System;
using Ardalis.ApiEndpoints;
using Battleship.API.Core.Contracts.Services;
using Battleship.API.Core.Models.DTOs.Challenges;
using Battleship.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Battleship.API.Endpoints.Challenges;

[Route("api/challenges")]
[Authorize]
public class NewChallengeEndpoint : EndpointBaseAsync.WithRequest<NewChallengeInputDTO>.WithActionResult<NewChallengeResultDTO>
{
    private readonly IChallengeService _challengeService;

    public NewChallengeEndpoint(IChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpPost("new")]
    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Challenges a player to a game",
        Description = "The authenticated player issues a new challenge to another player.",
        OperationId = "Challenges.New",
        Tags = new[] { "Challenges" })]
    public override async Task<ActionResult<NewChallengeResultDTO>> HandleAsync(NewChallengeInputDTO request, CancellationToken cancellationToken = default)
    {
        var challengerId = User.GetId();
        var result = await _challengeService.NewAsync(challengerId, request);

        return Ok(result);
    }
}
