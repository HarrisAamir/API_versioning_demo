﻿using API_Versioning.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/PathVersioning")]
    public class PathVersioningController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public PathVersioningController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok("This is version 1.0 of api path versioning");

    }
}
