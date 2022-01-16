namespace WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PinPointLocationsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreatePinPointLocation([FromBody] CreatePinPointLocationCommand command)
    {
        try
        {
            return Ok(await Mediator.Send(command));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
