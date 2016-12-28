using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ThouShallNotPass.Api.Controllers
{
    [Route("api/[controller]")]
    public class PasswordGeneratorController : Controller
    {
        
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<string> Generate()
        {
            return new string[] { "value1", "value2" };
        }
        
    }
}
