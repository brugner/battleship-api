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
public class ChallengesEndpoint : EndpointBaseAsync.WithRequest<ChallengesInputDTO>.WithActionResult<IEnumerable<ChallengeDTO>>
{
    private readonly IChallengeService _challengeService;

    public ChallengesEndpoint(IChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK), ProducesResponseType(StatusCodes.Status400BadRequest), ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerOperation(
        Summary = "Returns a collection of challenges",
        Description = "Returns a collection of challenges. If specified, a status filter is applied. The list contains all the challenges where the authenticated user is involved, either as a challenger or challengee.",
        OperationId = "Challenges.All",
        Tags = new[] { "Challenges" })]
    public override async Task<ActionResult<IEnumerable<ChallengeDTO>>> HandleAsync([FromQuery] ChallengesInputDTO request, CancellationToken cancellationToken = default)
    {
        var result = await _challengeService.GetAllAsync(request);

        return Ok(result);
    }
}
