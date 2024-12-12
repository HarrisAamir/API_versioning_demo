using API_Versioning.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.NewController
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiVersion("1.1")] 
    [Route("api/v{version:apiVersion}/Test")]
    public class TestController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public TestController(IProductRepository repository)
        {
            _repository = repository;
        }

        //[Obsolete("This api is obsolete.")]
        [HttpGet]
        [MapToApiVersion("1.0")] 
        public IActionResult GetAllV1()
        {
            return Ok(new { Version = "1.0", Message = "This is version 1.0 of api path versioning"});
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        public IActionResult GetAllV()
        {
            return Ok(new { Version = "1.1", Message = "This is version 1.1 of api path versioning" });
        }
    }
}
