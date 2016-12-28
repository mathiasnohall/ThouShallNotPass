using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ThouShallNotPass.Services;

namespace ThouShallNotPass.Api.Controllers
{
    [Route("api/[controller]")]
    public class PasswordGeneratorController : Controller
    {
        private readonly IPasswordGeneratorService _passwordGeneratorService;             

        public PasswordGeneratorController(IPasswordGeneratorService passwordGeneratorService)
        {
            _passwordGeneratorService = passwordGeneratorService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Generate()
        {
            return Ok(_passwordGeneratorService.Generate());
        }
        
    }
}
