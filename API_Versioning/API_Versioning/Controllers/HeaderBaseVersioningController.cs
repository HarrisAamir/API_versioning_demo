using API_Versioning.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiController]
    [Route("api/HeaderBaseVersioning")]
    [ApiVersion("1.0", Deprecated = true)]
    public class HeaderBaseVersioningController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public HeaderBaseVersioningController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok("This is version 1.0 of api header versioning");

    }
}
