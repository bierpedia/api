using Microsoft.AspNetCore.Mvc;

namespace Bierpedia.Api.Controller {

	[ApiVersion("1.0")]
	[ApiController]
	[Route("api/v{version:apiVersion}/[controller]")]
	public abstract class BeerpediaApiController : ControllerBase {

	}
}
