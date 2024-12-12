using API_Versioning.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiController]
    [Route("api/HeaderBaseVersioning")]
    [ApiVersion("1.0")]
    public class HeaderBaseVersioningController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public HeaderBaseVersioningController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    }
}
