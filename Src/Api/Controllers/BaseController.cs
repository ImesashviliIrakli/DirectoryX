using Domain.Abstractions;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public abstract class BaseController : ControllerBase
{
    protected IActionResult CreateResponse(Result result)
    {
        if (result.Code.Equals(GlobalStatusCodes.Success))
            return Ok(result);

        switch (result.Code)
        {
            case GlobalStatusCodes.NotFound:
                return NotFound(result);
            case GlobalStatusCodes.BadRequest:
            case GlobalStatusCodes.ValidationError:
                return BadRequest(result);
            case GlobalStatusCodes.Forbidden:
                return StatusCode(403, result);
            default:
                return StatusCode(500, result);

        }
    }
}