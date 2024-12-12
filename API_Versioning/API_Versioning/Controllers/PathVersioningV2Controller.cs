using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/PathVersioning")]
    public class PathVersioningV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok("This is version 2.0 of api path versioning");
    }
}
