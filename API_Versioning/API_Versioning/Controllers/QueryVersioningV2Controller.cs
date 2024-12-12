using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiController]
    [Route("api/QueryVersioning")]
    [ApiVersion("2.0")]
    public class QueryVersioningV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok("This is version 2.0 of api query params versioning");
    }
}
