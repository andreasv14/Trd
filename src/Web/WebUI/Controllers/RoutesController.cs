namespace WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoutesController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateRoute([FromBody] CreateRouteCommand command)
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

    [HttpGet]
    public async Task<ActionResult<TransportationRouteDto>> GetTransportationRoute([FromQuery] GetTransportationRouteQuery request)
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
}
