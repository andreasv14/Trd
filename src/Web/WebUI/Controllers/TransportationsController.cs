namespace WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransportationsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransportationDto>>> GetTransportations()
    {
        try
        {
            return Ok(await Mediator.Send(new GetTransportationsQuery()));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateTransportation([FromBody] CreateTransportationCommand command)
    {
        try
        {
            await Mediator.Send(command);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("route")]
    public async Task<ActionResult> UpdateTransportationRoute([FromBody] UpdateTransportationRouteCommand command)
    {
        try
        {
            await Mediator.Send(command);

            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
