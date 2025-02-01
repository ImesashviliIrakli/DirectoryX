using Application.RelatedIndividuals.AddRelatedIndividual;
using Application.RelatedIndividuals.DeleteRelatedIndividual;
using Application.RelatedIndividuals.GetRelatedIndividuals;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/related-individuals")]
[ApiController]
public class RelatedIndividualsController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet("report")]
    public async Task<IActionResult> Report(CancellationToken cancellationToken = default)
    {
        var query = new GetRelatedIndividualsQuery();

        var response = await _mediator.Send(query, cancellationToken);

        return CreateResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddRelatedIndividualCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CreateResponse(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteRelatedIndividualCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CreateResponse(response);
    }
}
