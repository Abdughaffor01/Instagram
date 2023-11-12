namespace WebApi.Controllers;

[Route("[controller]")]
[Authorize]
public class BaseController : ControllerBase
{
    [NonAction]
    protected List<string> ModelStateErrors() =>
        ModelState.SelectMany(e => e.Value.Errors.Select(er => er.ErrorMessage)).ToList();
}