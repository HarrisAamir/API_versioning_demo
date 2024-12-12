using API_Versioning.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.NewController
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")] // Add additional version
    [Route("api/TestQuery")]
    public class TestQueryController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public TestQueryController(IProductRepository repository)
        {
            _repository = repository;
        }

        // Method for version 1.0
        [HttpGet]
        [MapToApiVersion("1.0")] // Explicitly map this method to version 1.0
        public async Task<IActionResult> GetAllV1()
        {
            var products = await _repository.GetAllAsync();
            return Ok(new { Version = "1.0", Products = products });
        }

        // Method for version 2.0
        [HttpGet]
        [MapToApiVersion("2.0")] // Explicitly map this method to version 2.0
        public IActionResult GetAllV()
        {
            return Ok(new { Version = "2.0", Message = "This is version 2 of the API." });
        }
    }
}
