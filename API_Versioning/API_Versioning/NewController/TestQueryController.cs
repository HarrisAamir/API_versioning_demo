using API_Versioning.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.NewController
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")] 
    [Route("api/TestQuery")]
    public class TestQueryController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public TestQueryController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [MapToApiVersion("1.0")] 
        public IActionResult GetAll() => Ok(new { Version = "1.0", Message = "This is version 1.0 of api query params versioning" });

        [HttpGet]
        [MapToApiVersion("1.1")]
        public IActionResult GetAllV1_1() => Ok(new { Version = "1.1", Message = "This is version 1.1 of api query params versioning" });
    }
}
