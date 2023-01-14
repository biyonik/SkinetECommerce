using Microsoft.AspNetCore.Mvc;

namespace SkinetECommerce.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Produces("application/json")]
public class BaseController : ControllerBase
{
}