using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly ILogger<DrinkController> _logger;

        public DrinkController(ILogger<DrinkController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetDrinks()
        {
            return Ok();
        }

    }
}
