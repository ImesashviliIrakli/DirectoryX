using Application.Individuals.AddIndividual;
using Application.Individuals.DeleteIndividual;
using Application.Individuals.GetIndividualById;
using Application.Individuals.GetIndividuals;
using Application.Individuals.UpdateIndividual;
using Application.Individuals.UpdateIndividualPicture;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/individuals")]
[ApiController]
public class IndividualsController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("Search")]
    public async Task<IActionResult> Search([FromBody] GetIndividualsQuery query, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(query, cancellationToken);

        return CreateResponse(response);
    }

    [HttpGet("{individualId:int}")]
    public async Task<IActionResult> Get(int individualId, CancellationToken cancellationToken = default)
    {
        var query = new GetIndividualByIdQuery(individualId);

        var response = await _mediator.Send(query, cancellationToken);

        return CreateResponse(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddIndividualCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CreateResponse(response);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateIndividualCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return CreateResponse(response);
    }


    [HttpPost("update-picture")]
    public async Task<IActionResult> UpdatePicture([FromForm] int individualId, IFormFile file, CancellationToken cancellationToken = default)
    {
        var command = new UpdateIndividualPictureCommand(individualId, file);

        var response = await _mediator.Send(command, cancellationToken);

        return CreateResponse(response);
    }

    [HttpDelete("{individualId:int}")]
    public async Task<IActionResult> Delete(int individualId, CancellationToken cancellationToken = default)
    {
        var command = new DeleteIndividualCommand(individualId);

        var response = await _mediator.Send(command, cancellationToken);

        return CreateResponse(response);
    }

}
