using Application.Individuals.AddIndividual;
using Application.Individuals.UpdateIndividual;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/Individuals")]
[ApiController]
public class IndividualsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddIndividualCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateIndividualCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }
}
