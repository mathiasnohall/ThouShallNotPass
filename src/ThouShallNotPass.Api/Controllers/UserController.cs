using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ThouShallNotPass.Services;

namespace ThouShallNotPass.Api.Controllers
{
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromBody]dynamic user)
        {
            var result = await _userService.CreateUser(user.userName);

            return Ok();
        }
    }
}
