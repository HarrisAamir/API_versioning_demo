using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiController]
    [Route("api/HeaderBaseVersioning")]
    //[Route("api/[controller]")]
    [ApiVersion("2.0")]
    public class HeaderBaseVersioningV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll() => Ok("This is version 2.0 of api header versioning");
    }
}
