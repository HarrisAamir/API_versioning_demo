using API_Versioning.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    public class QueryVersioningController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public QueryVersioningController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok("This is version 1.0 of api query params versioning");

    }
}
