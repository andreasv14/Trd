namespace WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<TransportationLocationDto>> GetTransportationLocation([FromQuery] GetTransportationLocationQuery request)
    {
        try
        {
            return Ok(await Mediator.Send(request));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateTransportationLocation([FromBody] CreateTransportationLocationCommand command)
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
